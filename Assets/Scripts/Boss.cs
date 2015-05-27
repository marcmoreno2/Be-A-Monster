using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

	public int vidaboss=1000;
	public GameObject Barrera;
	private bool contBarrera=true;
	private int vidab=100;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () 
	{
	
		if (vidaboss <= 750) {
			if (contBarrera) {
				Instantiate (Barrera, this.transform.position, this.transform.rotation);
				contBarrera = false;
				if(vidab==0)
				{
					contBarrera=true;
				}
			}
		}
		if (vidaboss <= 500)
		{

		}
	}			

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Arma player")
		{
			if (tag == "Puerta")
			{
				vidaboss-=10;
				Debug.Log ("Puerta");
				Debug.Log (vidaboss);
			} 
			else
			{
				vidaboss -= 30;
				Debug.Log("Cabeza");
				Debug.Log (vidaboss);
			}
		}
	}
}
