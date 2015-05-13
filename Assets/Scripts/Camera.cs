using UnityEngine;
using System.Collections;

[RequireComponent (typeof(SpriteRenderer))]

public class Camera : MonoBehaviour {

	public GameObject player;
	//public int offset = 2;
	public bool boss;
	// Use this for initialization
	void Start () {
		Physics2D.IgnoreLayerCollision (5, 10);
		Physics2D.IgnoreLayerCollision (5, 11);
	}
	
	// Update is called once per frame
	void Update () {
		if (!boss) {
			this.transform.position = new Vector3 (player.transform.position.x + 1.5f, (player.transform.position.y + 1.1f) - (0.3f * player.transform.position.y), this.transform.position.z);
		} else {
			this.transform.position = new Vector3 (player.transform.position.x + 1.5f, player.transform.position.y + 1.1f, this.transform.position.z);
		}
	}
}
