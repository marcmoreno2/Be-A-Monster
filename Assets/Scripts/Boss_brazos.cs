﻿using UnityEngine;
using System.Collections;

public class Boss_brazos : MonoBehaviour {
	public GameObject jugador;
	private Player p;
	private int liberar;
	private Vector3 aux;


	// Use this for initialization
	void Start () {

		p=jugador.GetComponent<Player> () as Player;
		aux = p.transform.localScale;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D other)
	{

		if (other.tag == "Player") 
		{
			if (p.agarra) 
			{

				SystemVar.SystemVar.vidaPlayer-=0.5f;
				Debug.Log (SystemVar.SystemVar.vidaPlayer);
				if (Input.GetKeyDown (KeyCode.Z)) {
					Debug.Log ("LIBERATE");
					liberar++;
				}
				if (liberar >= 5) {
					p.agarra = false;
					p.transform.parent = null;
					p.GetComponent<Rigidbody2D> ().isKinematic = false;
					p.transform.rotation = new Quaternion (0, 0, 0, 0);
					p.faceright = false;
					aux.x = 1.4f;
					aux.y = 1.4f;
					p.transform.localScale = aux;
					liberar = 0;
				}
			}
			else
			{
				if (this.tag == "punyo")
				{
				p.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-70f, 1f));
				SystemVar.SystemVar.vidaPlayer-=5;
				Debug.Log ("GOLPEMANO");
				Debug.Log (SystemVar.SystemVar.vidaPlayer);
			
				}
			}
		}

	}
	
}
