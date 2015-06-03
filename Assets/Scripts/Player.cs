using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed, runSpeed;
	private Animator ani;
	public float salto, mov1, climbSpeed, saltoHR, saltoH;
	private int dir;
	public GameObject Estrella;
	public LayerMask layer_ground;
	public bool grounded, running, faceright = true, attack, agarra=false;
	public float atacVal;
	private Rigidbody2D rigbod;
	public Vector3 aux;
	private bool caerEscalera = false;
	private AudioSource[] ArraySoundAtk;

	// Use this for initialization
	void Start () {
		ani = GetComponent<Animator> ();
		rigbod = GetComponent<Rigidbody2D> ();
		ArraySoundAtk = GetComponents<AudioSource> ();
	//	fisicas = GetComponent<Rigidbody2D> ();
	}

	void SoundAtk(){
		ArraySoundAtk[Random.Range(0,3)].Play();
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (SystemVar.SystemVar.vidaPlayer > 500f)
			SystemVar.SystemVar.vidaPlayer = 500f;
		if (!agarra) {
			/*if (Input.GetKeyDown (KeyCode.Z)) {
				Instantiate (Estrella, this.transform.position, this.transform.rotation);
			}*/
			//grounded1 = Physics2D.Raycast(this.transform.position - new Vector3(-0.2f,0f,0f), new Vector2(0f, -1f), 0.8f, layer_ground);
			//grounded = Physics2D.Raycast(this.transform.position, new Vector2(0f, -1f), 0.8f, layer_ground);
			//grounded3 = Physics2D.Raycast(this.transform.position - new Vector3(0.2f,0f,0f), new Vector2(0f, -1f), 0.8f, layer_ground);
			//Physics2D.IgnoreLayerCollision (9, 10);
			if (Input.GetKey (KeyCode.LeftShift)) {
				running = true;
			} else
				running = false;
			if ((Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.LeftArrow)) && !attack) {
				if (Input.GetKey (KeyCode.RightArrow)) {
					if (!faceright) {
						Vector3 aux = transform.localScale;
						aux.x *= -1;
						transform.localScale = aux;
						faceright = true;
					}
					if (running)
						transform.Translate (1 * runSpeed * Time.deltaTime, 0f, 0f);
					else
						transform.Translate (1 * speed * Time.deltaTime, 0f, 0f);
					ani.SetBool ("walk", true);
				}
				if (Input.GetKey (KeyCode.LeftArrow)) {
					if (faceright) {
						Vector3 aux = transform.localScale;
						aux.x *= -1;
						transform.localScale = aux;
						faceright = false;
					}
					if (running)
						transform.Translate (-1 * runSpeed * Time.deltaTime, 0f, 0f);
					else
						transform.Translate (-1 * speed * Time.deltaTime, 0f, 0f);
					ani.SetBool ("walk", true);
				}
			} else
				ani.SetBool ("walk", false);

			//Debug.Log (rigbod.velocity);
			if (Input.GetKeyUp (KeyCode.LeftArrow) || Input.GetKeyUp (KeyCode.RightArrow) && rigbod.velocity.y != 0f) {
				//Debug.Log (rigbod.velocity);
				rigbod.velocity = new Vector2 (0f, rigbod.velocity.y);
			}

			if (Input.GetKey (KeyCode.Space) && grounded && !attack) {
				if (Input.GetKey (KeyCode.RightArrow)) {
					if (running)
						rigbod.AddForce (new Vector2 (saltoHR, salto));
					else
						rigbod.AddForce (new Vector2 (saltoH, salto));
				} else if (Input.GetKey (KeyCode.LeftArrow)) {
					if (running)
						rigbod.AddForce (new Vector2 (-saltoHR, salto));
					else
						rigbod.AddForce (new Vector2 (-saltoH, salto));
				}
			//Debug.Log ("Salta");
			else
					rigbod.AddForce (new Vector2 (0f, salto));
				grounded = false;
			}

			if (Input.GetKey (KeyCode.X) && grounded) {
				attack = true;
				ani.SetBool ("attack", true);		
			} else if (attack == true) {
				attack = false;
				ani.SetBool ("attack", false);
			}
		} 

		if(SystemVar.SystemVar.vidaPlayer<=0)
		{
			Destroy(this.gameObject);
		}
	}

	void OnDestroy(){
		Application.LoadLevel("Main_Menu");
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "rayo") {
			SystemVar.SystemVar.vidaPlayer -= 50f;
			ArraySoundAtk[3].Play();
		}
		if (other.gameObject.tag == "Mano") 
		{
			agarra=true;

		}
		if(other.tag == "LadderBot") {
			caerEscalera = true;
			rigbod.isKinematic=false;
			if(Input.GetKey (KeyCode.UpArrow))
				transform.Translate(0f, climbSpeed * Time.deltaTime, 0f);
		}
		if (other.tag == "Guardia") 
		{
			GameObject d = other.gameObject as GameObject;
			Guardia g = d.GetComponent<Guardia>() as Guardia;
			if(this.transform.position.x < d.transform.position.x)
			{
				if(g.embestida){
					rigbod.AddForce(new Vector2(-50f,200f));
					SystemVar.SystemVar.vidaPlayer-=30f;
				}
				else if(g.ataque){
					rigbod.AddForce(new Vector2(-100f,400f));
					SystemVar.SystemVar.vidaPlayer-=20f;
				}
				ArraySoundAtk[3].Play();
			}
			else
			{
				if(g.embestida){
					rigbod.AddForce(new Vector2(50f,200f));
					SystemVar.SystemVar.vidaPlayer-=30f;
				}
				else if(g.ataque){
					rigbod.AddForce(new Vector2(100f,400f));
					SystemVar.SystemVar.vidaPlayer-=20f;
				}
				ArraySoundAtk[3].Play();

			}
		}


	}
	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "LadderTop") {
			if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
			{
				rigbod.isKinematic = false;
				ani.SetBool("onLadder", false);
				ani.speed=1;
			}else if(Input.GetKey(KeyCode.DownArrow)){
				rigbod.isKinematic = true;
				ani.SetBool("onLadder", true);
				ani.speed = 0.5f;
				transform.Translate (0f, -climbSpeed * Time.deltaTime, 0f);
			}
		}

		if (other.name == "LadderCollider")
		{
			if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow))
			{
				rigbod.isKinematic = true;
				ani.SetBool("onLadder", true);
				ani.speed=0;
			}

			if (Input.GetKey(KeyCode.UpArrow )){
				caerEscalera = false;
				ani.speed = 0.5f;
				transform.Translate (0f, climbSpeed * Time.deltaTime, 0f);
			}
			else if (Input.GetKey(KeyCode.DownArrow )&& !caerEscalera)
			{


				ani.speed = 0.5f;
				transform.Translate (0f, -climbSpeed * Time.deltaTime, 0f);
			}
			else ani.speed = 0;
		}

	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.name == "LadderCollider") {
			rigbod.isKinematic = false;
			ani.speed = 1;
			ani.SetBool("onLadder", false);
		}
	}
	void OnCollisionEnter2D (Collision2D other)
	{
		//Debug.Log (other.transform.name);
		if (other.gameObject.tag == "floor" || other.gameObject.tag == "plat_peke" || other.gameObject.name == "prefPlat_med" || other.gameObject.tag=="Boss" || other.gameObject.tag== "Mano")
		{
			grounded = true;
		}

	}


	void OnCollisionStay2D(Collision2D other)
	{
		if (other.gameObject.name == "prefPlat_med") 
		{
			this.transform.parent=other.transform;
		}
	}

	void OnCollisionExit2D(Collision2D other)
	{
		if (other.gameObject.name == "prefPlat_med") 
		{
			this.transform.parent=null;
		}
	}

}