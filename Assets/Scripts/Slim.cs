using UnityEngine;
using System.Collections;


	
	public class Slim : MonoBehaviour {
		
		private Animator ani;
		
		public Transform sightStart, sightEnd;
		//public Rigidbody rb;
		public bool alerta = false;
		public bool campana =false;
		public GameObject bocadillo,PocionS,Hamburguesa,Pollo;
		public float fuerzaDrop;
		public float vel=-3;
		public string name;
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
		if(!toc)
			transform.Translate (vel*Time.deltaTime,0.0f,0.0f);
			//Physics2D.IgnoreLayerCollision (10, 10);
			//Physics2D.IgnoreLayerCollision (10, 12);
			
			
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

					Physics2D.IgnoreLayerCollision (10, 11,true);
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
				if(vel<0)
				{
					vel=-vel;
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
		if (other.tag == "Player") 
		{
			Destroy(this.gameObject);
			//Debug.Log ("TocaPlayer");	
		}
		//	Debug.Log ("Hit1");	
			if (other.tag == "Player") {
			//	Debug.Log ("Hit2");	
				/*if (name == "Casa1")
					SystemVar.SystemVar.contCasa1--;
				else if (name == "Casa2")
					SystemVar.SystemVar.contCasa2--;*/
				GameObject casa = GameObject.Find(name) as GameObject;
				Casa _C = casa.GetComponent("Casa") as Casa;
				_C.spawn = true;
				//Casa _C = GameObject.Find(name).GetComponent("Casa") as Casa;

				float rand = Random.Range (0.0f, 100.0f);
				if (rand <= 25) {
					GameObject p = Instantiate (PocionS, this.transform.position, this.transform.rotation) as GameObject;
					p.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (50f, fuerzaDrop));
				} else if (rand <= 50) {
					GameObject p = Instantiate (Hamburguesa, this.transform.position, this.transform.rotation) as GameObject;
					p.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (50f, fuerzaDrop));
				} else if (rand <= 75) {
					GameObject p = Instantiate (Pollo, this.transform.position, this.transform.rotation) as GameObject;
					p.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (50f, fuerzaDrop));
				}
				Destroy (this.gameObject);
			}
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
	}
		
}