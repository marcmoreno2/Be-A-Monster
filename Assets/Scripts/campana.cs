using UnityEngine;
using System.Collections;

public class campana : MonoBehaviour {
	private Animator ani;
	// Use this for initialization
	void Start () {
		ani = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Slim") 
		{
			Debug.Log ("tocado");
			ani.SetBool("tocado",true);
		}
	}
}
