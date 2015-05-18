using UnityEngine;
using System.Collections;

public class Guardia : MonoBehaviour {

	private Animator ani;
	public float vel=-3;
	public Transform sightStart, sightEnd;
	public bool alerta = false;
	public bool ataque = false;
	public float velfin=-3;
	public GameObject Atak;
	public float vel_ataq=0;

	// Use this for initialization
	void Start () {
		ani = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		RayCasting ();
		Behaviours ();
		Ataque ();
		transform.Translate (vel*Time.deltaTime,0.0f,0.0f);
		Physics2D.IgnoreLayerCollision (10, 10);
	}

	void RayCasting()
	{
		Debug.DrawLine (sightStart.position, sightEnd.position, Color.green);
		alerta = Physics2D.Linecast (sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer("Player"));

	}

	void Ataque()
	{

		if (ataque) {
			GameObject B = Instantiate(Atak, this.transform.position - new Vector3(vel_ataq,0.35f,0f), this.transform.rotation) as GameObject;
			B.transform.parent = transform;

			ataque=false;
		}
	}

	void Behaviours()
	{
		if (alerta)
		{
			velfin=vel;
			vel = 0;
			ani.SetBool ("ataque", true);
			ataque=true;
			vel=velfin;
		}
		else
		{

			ani.SetBool("ataque",false);

		}

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "rebote") 
		{
			vel = -vel;
			Vector3 aux = transform.localScale;
			aux.x *= -1;
			transform.localScale = aux;
			
		}
	}

}
