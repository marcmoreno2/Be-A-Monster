﻿using UnityEngine;
using System.Collections;

public class Boss_brazos : MonoBehaviour {

	public int vida_avatar=100;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			Debug.Log ("DAÑO");
			vida_avatar--;
		}
	}
}
