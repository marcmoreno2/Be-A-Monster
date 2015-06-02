using UnityEngine;
using System.Collections;

public class Boss_end : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.GetComponent<Renderer> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (SystemVar.SystemVar.startboss == true && SystemVar.SystemVar.vidaBoss<=0)
		{
			this.GetComponent<Renderer> ().enabled = true;
		}
	}
}
