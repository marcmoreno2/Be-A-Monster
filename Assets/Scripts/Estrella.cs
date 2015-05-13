using UnityEngine;
using System.Collections;

public class Estrella : MonoBehaviour {

	public float vel=5.0f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(vel*Time.deltaTime,0.0f,0.0f);
	}
	void OnBecameInvisible()
	{
		Destroy (gameObject);
	}
}
