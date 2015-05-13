using UnityEngine;
using System.Collections;

public class prefPlatPek : MonoBehaviour {

	private float inix, iniy;
private int p;

	// Use this for initialization
	void Start () {
		//p = CreadorPla;
		inix = transform.position.x;
		iniy = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other){

		StartCoroutine ("Caer");

	}

	IEnumerator Caer(){

		yield return new WaitForSeconds(1);

		GetComponent<Rigidbody2D>().isKinematic = false;
		//
		yield return new WaitForSeconds (0.3f);

		this.GetComponent<Renderer>().enabled = false;
		this.GetComponent<BoxCollider2D> ().enabled = false;
		yield return new WaitForSeconds (1);

		this.GetComponent<Renderer>().enabled = true;
		GetComponent<Rigidbody2D>().isKinematic = true;
		this.transform.position = new Vector3 (inix, iniy, 0);
		this.GetComponent<BoxCollider2D> ().enabled = true;

		StopCoroutine ("Caer");
	}
}