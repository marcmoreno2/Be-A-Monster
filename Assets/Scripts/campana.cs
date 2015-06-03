using UnityEngine;
using System.Collections;

public class campana : MonoBehaviour {
	private Animator ani;
	private bool ok;
	// Use this for initialization
	void Start () {
		ani = GetComponent<Animator> ();
		ok = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Slim" && ok) 
		{
			ok = false;
			//Debug.Log ("tocado");
			ani.SetBool("tocado",true);
			SystemVar.SystemVar.guardias=true;
			GetComponent<ParticleSystem>().Play();

		}
	}
}
