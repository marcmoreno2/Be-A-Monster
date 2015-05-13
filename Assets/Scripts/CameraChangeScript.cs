using UnityEngine;
using System.Collections;

public class CameraChangeScript : MonoBehaviour {

	public Animator CamAni;
	// Use this for initialization
	void Start () {
		CamAni = FindObjectOfType<Camera> ().GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.name == "prefPlayer") {
			//FindObjectOfType<Camera>().boss = true;
			CamAni.SetBool("Boss", true);
		}
	}
}
