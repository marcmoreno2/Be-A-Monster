using UnityEngine;
using System.Collections;

public class Parallax1 : MonoBehaviour {

	//public Transform[] backgrounds;
	//private float[] parallaxScales;
	public float offsetY;
	public GameObject player;

	//public Transform cam;
	private Vector3 previousCamPos;

	//private Vector3 StartPos;

	// Use this for initialization
	void Start () {
		previousCamPos = transform.parent.position;
	}

	// Update is called once per frame
	void Update () {
		float parallax = (previousCamPos.x - transform.parent.transform.position.x) * -1f;
		float backgroundDestPosX = transform.position.x + parallax*-0.1f;
		transform.position = new Vector3 (backgroundDestPosX, (transform.parent.transform.position.y - offsetY)-(player.transform.position.y*+0.2f));
		previousCamPos = transform.parent.position;
	}
}
