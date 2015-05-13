using UnityEngine;
using System.Collections;

public class Pollo : MonoBehaviour {
	void Start () {
		
	}
	void Update () {
		Physics2D.IgnoreLayerCollision (13, 13);
	}

	void OnCollisionEnter2D(Collision2D other)
	{

		if (other.gameObject.tag == "Player") 
		{
			Destroy(this.gameObject);
		}
	}
}
