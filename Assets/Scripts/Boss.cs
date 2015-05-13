using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

	public int vida=1000;
	public GameObject Barrera;
	private bool contBarrera=true;
	private int vidab=100;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () 
	{
	
		if (vida <= 750) {
			if (contBarrera) {
				Instantiate (Barrera, this.transform.position, this.transform.rotation);
				contBarrera = false;
				if(vidab==0)
				{
					contBarrera=true;
				}
			}
		}
		if (vida <= 500)
		{

		}
	}			

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			vida -= 10;
			Debug.Log (vida);
		}
	}
}
