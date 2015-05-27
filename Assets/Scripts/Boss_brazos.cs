using UnityEngine;
using System.Collections;

public class Boss_brazos : MonoBehaviour {
	public GameObject jugador;
	private Player p;
	private int liberar;
	private Vector3 aux;


	// Use this for initialization
	void Start () {

		p=jugador.GetComponent<Player> () as Player;
		aux = p.transform.localScale;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D other)
	{


		if (other.tag == "Player")
		{
			if(p.agarra)
			{

				SystemVar.SystemVar.vidaPlayer--;
				Debug.Log(SystemVar.SystemVar.vidaPlayer);
				if(Input.GetKeyDown (KeyCode.Z))
				{
					liberar++;
				}
				if(liberar>=5)
				{
					p.agarra=false;
					p.transform.parent=null;
					p.GetComponent<Rigidbody2D>().isKinematic=false;
					p.transform.rotation=new Quaternion(0,0,0,0);
					p.faceright=false;
					aux.x=1.5f;
					aux.y=1.5f;
					liberar=0;
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
