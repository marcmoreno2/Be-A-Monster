using UnityEngine;
using System.Collections;

public class Guardia : MonoBehaviour {

	private Animator ani;
	public int freq = 50, i;
	public float vel=-3;
	private float antVel;
	public GameObject PocionS,Hamburguesa,Pollo, Terremoto;
	public Transform sightStart, sightEnd;
	public bool alerta = false, muerte = false, moviment = true;
	public float  vida = 300, fuerzaDrop;
	//public GameObject Atak;
	//public float vel_ataq = 0;

	// Use this for initialization
	void Start () {
		ani = GetComponent<Animator> ();
		name = this.gameObject.name;
	
	}
	
	// Update is called once per frame
	void Update () {
		RayCasting ();
		Behaviours ();
		if (moviment)
			transform.Translate (vel*Time.deltaTime,0.0f,0.0f);
	}

	void RayCasting()
	{
		Debug.DrawLine (sightStart.position, sightEnd.position, Color.green);
		alerta = Physics2D.Linecast (sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer("Player"));

	}

	void Terr()
	{
		GameObject B = Instantiate(Terremoto, this.transform.position - new Vector3(0.2f*vel,0.2f,0),this.transform.rotation) as GameObject;
		Terremoto C = B.GetComponent("Terremoto") as Terremoto;
		C.dir=this.vel;
	}

	void movStop(){
		moviment = false;
	}

	void movStart(){
		moviment = true;
	}

	void muerto(){
		float rand = Random.Range(0.0f, 100.0f);
		if(rand <=25)
		{
			GameObject p = Instantiate(PocionS, this.transform.position, this.transform.rotation) as GameObject;
			p.GetComponent<Rigidbody2D>().AddForce(new Vector2(50f,fuerzaDrop));
		}
		else if(rand <=50)
		{
			GameObject p = Instantiate(Hamburguesa, this.transform.position, this.transform.rotation) as GameObject;
			p.GetComponent<Rigidbody2D>().AddForce(new Vector2(50f,fuerzaDrop));
		}
		else if(rand <=75)
		{
			GameObject p = Instantiate(Pollo, this.transform.position, this.transform.rotation) as GameObject;
			p.GetComponent<Rigidbody2D>().AddForce(new Vector2(50f,fuerzaDrop));
		}
		//muerte = true;
		Destroy(gameObject, 0.3f);
	}

	void Behaviours()
	{
		if (alerta)
		{
			moviment = false;
			ani.SetBool ("ataque", true);
		}
		else
		{
			//moviment = true;
			ani.SetBool("ataque",false);
		}


		if (vida <= 0f) {
			//moviment = false;

			ani.SetBool("muerte", true);
		}

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "rebote") 
		{

			vel = -vel;
			Vector3 aux = transform.localScale;
			aux.x *= -1;
			transform.localScale = aux;
			
		}
		if (other.tag == "Arma player") {
			vida -= SystemVar.SystemVar.playerAtack;
		}

	}

	void OnDestroy()
	{
		SystemVar.SystemVar.score += 30f;
	}

}
