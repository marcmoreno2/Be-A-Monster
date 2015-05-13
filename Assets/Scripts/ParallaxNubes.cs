using UnityEngine;
using System.Collections;

public class ParallaxNubes : MonoBehaviour {


	public Material materials;
	public Renderer rend;
	public float velocity;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 offset = rend.sharedMaterial.GetTextureOffset("_MainTex") +new Vector2( 0.0003f, 0f);
		rend.sharedMaterial.SetTextureOffset("_MainTex", offset);
	}
}
