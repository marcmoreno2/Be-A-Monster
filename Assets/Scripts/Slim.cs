using UnityEngine;
using System.Collections;


	
public class Slim : MonoBehaviour {

	private Animator ani;

	public Transform sightStart, sightEnd;
	//public Rigidbody rb;
	public bool alerta = false;
	public bool campana =false;
	public GameObject bocadillo,PocionS,Hamburguesa,Pollo;
	public float fuerzaDrop, vida;
	public float vel=-3;
	public string name;
	public bool toc = false;
	public bool deathC;
	// Use this for initialization
	void Start ()
	{
		//Debug.Log (transform.parent.name);
		ani = GetComponent<Animator> ();
		//InvokeRepeating ("Patrol",0.0f,Random.Range(2f,5f));
	   

	}

	// Update is called once per frame
	void Update ()
	{
		RayCasting ();
		Behaviours ();
		checkDeath ();

		if(!toc)
			transform.Translate (vel*Time.deltaTime,0.0f,0.0f);
		transform.parent = null;
	}

	void checkDeath()
	{
		if (vida <= 0) {
			//GetComponentInParent<Casa> ().spawn = true;
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
			deathC = true;
			Destroy (this.gameObject,0.01f);
		}
	}

	void RayCasting()
	{
		Debug.DrawLine (sightStart.position, sightEnd.position, Color.green);
		alerta = Physics2D.Linecast (sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer("Player"));
	}

	void Behaviours()
	{
		if (alerta == true) {
			bocadillo.SetActive (true);
			campana=true;
			if(vel<0)
			{
				vel=-vel;
				Vector3 aux=transform.localScale;
				aux.x*=-1;
				transform.localScale = aux;
			}
		}
	}
		
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "rebote" && !campana) {
			vel = -vel;
			Vector3 aux = transform.localScale;
			aux.x *= -1;
			transform.localScale = aux;
		}
		if (other.tag == "campana")
		{
			toc = true;
			other.GetComponent<Animator>() .SetBool("tocado",true);
		}
		if (other.tag == "Arma player")
			vida -= SystemVar.SystemVar.playerAtack;
	}
		
}