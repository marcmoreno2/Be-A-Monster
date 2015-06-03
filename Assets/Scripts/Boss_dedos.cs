using UnityEngine;
using System.Collections;

public class Boss_dedos : MonoBehaviour {
	public GameObject jugador;
	private Player p;
	private Renderer r;
	// Use this for initialization
	void Start () {
		r = GetComponent<Renderer> ();
		p=jugador.GetComponent<Player> () as Player;

	}
	
	// Update is called once per frame
	void Update () {
		if (p.agarra) 
		{
			r.enabled = true;
		} 
		else
		{
			r.enabled = false;
		}
	}
}