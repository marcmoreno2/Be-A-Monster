using UnityEngine;
using System.Collections;

public class Guardia : MonoBehaviour {

	private Animator ani;
	public float vel=-3;
	public Transform sightStart, sightEnd;
	public bool alerta = false;
	// Use this for initialization
	void Start () {
		ani = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		RayCasting ();
		Behaviours ();
		transform.Translate (vel*Time.deltaTime,0.0f,0.0f);
	}

	void RayCasting()
	{
		Debug.DrawLine (sightStart.position, sightEnd.position, Color.green);
		alerta = Physics2D.Linecast (sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer("Player"));
		
		
		
	}

	void Behaviours()
	{


	}
}
