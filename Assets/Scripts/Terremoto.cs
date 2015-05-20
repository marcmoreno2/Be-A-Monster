using UnityEngine;
using System.Collections;

public class Terremoto : MonoBehaviour {

	public float dir;
	private int cont=0;
	private float timer=0;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		timer = Time.deltaTime;
		if(timer-Time.deltaTime>0.5f)
		{
			timer=Time.deltaTime;
		if (cont < 7) 
		{
			transform.Translate(new Vector3(dir,0f,0f));
		}
		}
		Destroy(this.gameObject);

	}
}
