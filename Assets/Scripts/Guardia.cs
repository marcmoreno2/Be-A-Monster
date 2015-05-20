﻿using UnityEngine;
using System.Collections;

public class Guardia : MonoBehaviour {

	private Animator ani;
	public float vel=-3;

	public GameObject PocionS,Hamburguesa,Pollo, Terremoto;
	public Transform sightStart, sightEnd;
	public bool alerta = false, muerte = false;

	public float  vida = 200, fuerzaDrop;
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

		transform.Translate (vel*Time.deltaTime,0.0f,0.0f);
		Physics2D.IgnoreLayerCollision (10, 10);
	}

	void RayCasting()
	{
		Debug.DrawLine (sightStart.position, sightEnd.position, Color.green);
		alerta = Physics2D.Linecast (sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer("Player"));

	}



	void Behaviours()
	{
		if (alerta)
		{

			vel = 0;
			ani.SetBool ("ataque", true);
			GameObject B=Instantiate(Terremoto, this.transform.position - new Vector3(0.1f*vel,0.5f,0),this.transform.rotation) as GameObject;
			Terremoto C=B.GetComponent("Terremoto") as Terremoto;
			C.dir=this.vel;

		}
		else
		{

			ani.SetBool("ataque",false);


		}
		if (vida <= 0f && !muerte) {
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
			ani.SetBool("muerte", true);
			muerte = true;
			Destroy(gameObject, ani.GetCurrentAnimatorStateInfo(0).length);
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

}
