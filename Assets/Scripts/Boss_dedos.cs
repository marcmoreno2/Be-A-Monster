using UnityEngine;
using System.Collections;

public class Boss_dedos : MonoBehaviour {
	public GameObject jugador;
	private Player p;
	// Use this for initialization
	void Start () {

		p=jugador.GetComponent<Player> () as Player;

	}
	
	// Update is called once per frame
	void Update () {
		if (p.agarra) 
		{
			this.GetComponent<Renderer> ().enabled = true;
		} 
		else
		{
			this.GetComponent<Renderer> ().enabled = false;
		}
	}
}