using UnityEngine;
using System.Collections;

public class Hamburguesa : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Physics2D.IgnoreLayerCollision (13, 13);
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{
		
		if (other.gameObject.tag == "Player") 
		{
			SystemVar.SystemVar.score += 10f;
			SystemVar.SystemVar.vidaPlayer += 50f;
			Destroy(this.gameObject);
		}
	}
}
