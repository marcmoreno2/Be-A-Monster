using UnityEngine;
using System.Collections;

public class Guardia : MonoBehaviour {

	private Animator ani;
	public int freq, i;
	public float vel;
	private float antVel;
	private Rigidbody2D body;
	public GameObject PocionS,Hamburguesa,Pollo;
	public Transform sightStart, sightEnd;
	public bool alerta = false, muerte = false, moviment = true, alertat1 = true, embestida = false, ataque = false;
	public float  vida, fuerzaDrop, fuerzagolpe;
	private ParticleSystem part;
	private AudioSource au;
	//public GameObject Atak;
	//public float vel_ataq = 0;

	// Use this for initialization
	void Start () {
		freq = 50;
		vida = 300;
		fuerzagolpe = 1000f;
		vel=-3;
		ani = GetComponent<Animator> ();
		name = this.gameObject.name;
		body = GetComponent<Rigidbody2D> ();
		part = GetComponent<ParticleSystem> ();
		au = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		RayCasting ();
		Behaviours ();
		if (moviment)
			transform.Translate (vel*Time.deltaTime,0.0f,0.0f);
	}

	void playDeathSound()
	{
		au.Play ();
	}

	void RayCasting()
	{
		Debug.DrawLine (sightStart.position, sightEnd.position, Color.green);
		alerta = Physics2D.Linecast (sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer("Player"));

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
		Destroy(gameObject);
	}

	void Behaviours()
	{
		if (vida <= 0f) {
			moviment = false;
			muerte = true;
			ani.SetBool("muerte", true);
		}
		else if (alerta)
		{
			if (alertat1){
			
				vel *= 3;
				alertat1 = false;
				embestida = true;
				part.Play();

			}
			//moviment = false;
			//ani.SetBool ("ataque", true);
		}
		else
		{
			if (alertat1 == false){
				alertat1 = true;
				vel/= 3;
			}
			//moviment = true;
			ataque = false;
			ani.SetBool("ataque",false);
		}





	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "rebote" && !muerte) 
		{

			vel = -vel;
			Vector3 aux = transform.localScale;
			aux.x *= -1;
			transform.localScale = aux;
			
		}
		if (other.tag == "Arma player") {
			vida -= SystemVar.SystemVar.playerAtack;
			if (this.transform.position.x > other.transform.position.x)
				body.AddForce(new Vector2( fuerzagolpe, fuerzagolpe/3));
			else
				body.AddForce(new Vector2( -fuerzagolpe, fuerzagolpe/3));
		}
		if (other.tag == "Player" && alerta) {
			moviment = false;
			embestida = false;
			ataque = true;
			part.Stop ();
			ani.SetBool ("ataque", true);
		}

	}

	void OnDestroy()
	{
		SystemVar.SystemVar.score += 30f;
		SystemVar.SystemVar.contGuardias++;
		if (SystemVar.SystemVar.contGuardias == 1)
		{
			SystemVar.SystemVar.startboss=true;
		}
	}

}
