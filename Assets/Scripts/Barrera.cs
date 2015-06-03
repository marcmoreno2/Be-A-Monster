using UnityEngine;
using System.Collections;

public class Barrera : MonoBehaviour {

	private AreaEffector2D AE;

	// Use this for initialization
	void Start () 
	{
		AE = GetComponent<AreaEffector2D> ();
	}

	// Update is called once per frame
	void Update () 
	{
		if (SystemVar.SystemVar.contGuardias == 1) 
		{
			Destroy (gameObject);
			SystemVar.SystemVar.contGuardias = 0;
		}
	}
	void changeForceDirection()
	{
		Debug.Log (AE.forceDirection);
		AE.forceDirection = Random.Range (0f, 359f);
	}

	/* void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Arma player")
			vida -= 50f;
	} */
}
