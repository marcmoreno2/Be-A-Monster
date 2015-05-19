using UnityEngine;
using System.Collections;



public class SlimCampana : MonoBehaviour {
	
	private Animator ani;
	
	public Transform sightStart, sightEnd;
	//public Rigidbody rb;
	public bool alerta = false;
	public bool campana =false;
	public GameObject bocadillo,PocionS,Hamburguesa,Pollo;
	public float fuerzaDrop, vida;
	public float vel=0;
	public bool toc = false;
	
	// Use this for initialization
	void Start ()
	{
		ani = GetComponent<Animator> ();
		//InvokeRepeating ("Patrol",0.0f,Random.Range(2f,5f));
		
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		RayCasting ();
		Behaviours ();
		Campana ();
		transform.Translate (vel*Time.deltaTime,0.0f,0.0f);
		Physics2D.IgnoreLayerCollision (10, 10);
		Physics2D.IgnoreLayerCollision (10, 9);
		if (!toc)
			transform.Translate (vel * Time.deltaTime, 0.0f, 0.0f);
		else
			vel = 0;
		
	}
	
	void RayCasting()
	{
		Debug.DrawLine (sightStart.position, sightEnd.position, Color.green);
		alerta = Physics2D.Linecast (sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer("Player"));
		
		
		
	}
	void Campana()
	{
		if (campana)
		{
			if (vel > 0) 
			{
				Physics2D.IgnoreLayerCollision (10, 11);
			}
		} 
		else
		{
			Physics2D.IgnoreLayerCollision(10,11,false);
		}
	}
	void Behaviours()
	{
		
		if (alerta == true) {
			bocadillo.SetActive (true);
			campana=true;
			vel=4;
			if(vel>0)
			{

				Vector3 aux=transform.localScale;
				aux.x*=-1;
				transform.localScale = aux;

			}
		} 
		/*else
		{
			bocadillo.SetActive(false);
		}*/
		
	}
	
	
	
	void OnTriggerEnter2D(Collider2D other)
	{
		
		if (other.tag == "Arma player")
		{

			/*if(name == "Casa1")
				SystemVar.SystemVar.contCasa1--;
			else if(name == "Casa2")
				SystemVar.SystemVar.contCasa2--;*/
			
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
			Destroy (gameObject);
		}
		if (other.tag == "rebote") 
		{
			vel=-vel;
			Vector3 aux=transform.localScale;
			aux.x*=-1;
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