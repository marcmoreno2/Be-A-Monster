﻿using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

	public float vidaboss = 1000;
	public GameObject Barrera;
	private bool contBarrera=true;
	private int vidab=100;
	// Use this for initialization
	void Start () {

		this.GetComponent<Renderer> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		vidaboss = SystemVar.SystemVar.vidaBoss;
		//vidaboss = SystemVar.SystemVar.vidaBoss;
		if (vidaboss <= 750 && this.tag != "Puerta") {
			if (contBarrera) {
				/*Barrera barrera = */Instantiate (Barrera, this.transform.position, this.transform.rotation);// as Barrera;
				contBarrera = false;
				SystemVar.SystemVar.guardias=true;
				//Debug.Log (barrera.vida);
				//barrera.gameObject.
				/*if(barrera.vida<=0f)
				{
					Destroy(barrera);
					contBarrera=true;
				}*/
			}
		}
		if (vidaboss <= 500)
		{

		}
		if (vidaboss <= 0) {
			Destroy (gameObject, 2f);
			/*this.GetComponent<Rigidbody2D>().isKinematic = false;
			Barrera barrera = Instantiate (Barrera, this.transform.position, this.transform.rotation) as Barrera;
			barrera.GetComponent<AreaEffector2D>().forceDirection = 0f;
			Debug.Log(barrera.GetComponent<AreaEffector2D>().forceDirection);*/


		} 
		else if (SystemVar.SystemVar.startboss == true) 
		{
			this.GetComponent<Renderer> ().enabled = true;
		}
	}			

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Arma player")
		{
			if (tag == "Puerta")
			{
				SystemVar.SystemVar.vidaBoss -=10;
				Debug.Log ("Puerta");
				Debug.Log (vidaboss);
			} 
			else
			{
				SystemVar.SystemVar.vidaBoss  -= 30;
				Debug.Log("Cabeza");
				Debug.Log (vidaboss);
			}
		}
	}

	void Crear()
	{

	}
}
