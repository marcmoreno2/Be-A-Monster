using UnityEngine;
using System.Collections;

public class Boss_brazos : MonoBehaviour {
	public GameObject jugador;
	private Player p;

	// Use this for initialization
	void Start () {

		p=jugador.GetComponent<Player> () as Player;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			if(!p.agarra){

				SystemVar.SystemVar.vidaPlayer--;
				Debug.Log(SystemVar.SystemVar.vidaPlayer);
				if(Input.GetKeyDown (KeyCode.Z))
				{
					p.agarra=true;
					p.transform.parent=null;
					p.GetComponent<Rigidbody2D>().isKinematic=false;
					p.transform.rotation=new Quaternion(0,0,0,0);
				}
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (!p.agarra)
		{

		}
	}
}
