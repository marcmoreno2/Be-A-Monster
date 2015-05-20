using UnityEngine;
using System.Collections;

public class Terremoto : MonoBehaviour {

	public float dir;
	public GameObject copy;
	private int cont=0;
	private float timer=0, time = 0;
	private Animator ani;
	// Use this for initialization
	void Start () {
		ani = GetComponent<Animator> ();
		time = ani.GetCurrentAnimatorStateInfo (0).length;
	}
	
	// Update is called once per frame
	void Update () {
		//timer = Time.deltaTime;

		/*if(2 - timer>0.5f)
		{
			transform.Translate(new Vector3(dir*0.01f,0f,0f));
		}*/
		//Destroy(this.gameObject,time);

	}

	void moure()
	{
		transform.Translate(new Vector3(dir*0.2f,0f,0f));
	}
}
