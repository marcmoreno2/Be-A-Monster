﻿using UnityEngine;
using System.Collections;

public class Boss_start : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.GetComponent<Renderer> ().enabled = true;


	}
	
	// Update is called once per frame
	void Update () {

		if (SystemVar.SystemVar.startboss== true)
		{
			this.GetComponent<Renderer> ().enabled = false;
		}

	}
}
