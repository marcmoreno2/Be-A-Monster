using UnityEngine;
using System.Collections;

public class Boss_brazos : MonoBehaviour {
	public GameObject jugador;
	private Player p;
	private int liberar;
	private Vector3 aux;
	private float timer;
	private Rigidbody2D rigbod;

	// Use this for initialization
	void Start () {

		p=jugador.GetComponent<Player> () as Player;
		aux = p.transform.localScale;
		rigbod = p.GetComponent<Rigidbody2D> ();
		timer = 0;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D other)
	{

		if (other.tag == "Player") 
		{
			if (p.agarra) 
			{
				/*if(timer>=2f)
				{

					p.agarra = false;
					p.transform.parent = null;
					p.GetComponent<Rigidbody2D> ().isKinematic = false;
					p.transform.rotation = new Quaternion (0, 0, 0, 0);
					p.faceright = false;
					aux.x = 1.4f;
					aux.y = 1.4f;
					p.transform.localScale = aux;
					timer = 0;

				}
				else{

					timer+= 1 * Time.deltaTime;
					Debug.Log(timer);
					}*/



				SystemVar.SystemVar.vidaPlayer-=0.5f;
				//Debug.Log (SystemVar.SystemVar.vidaPlayer);
				if (Input.GetKeyDown (KeyCode.Z)) {
					//Debug.Log ("LIBERATE");
					liberar++;
				}
				if (liberar >= 5) {
					p.agarra = false;
					p.transform.parent = null;
					p.GetComponent<Rigidbody2D> ().isKinematic = false;
					p.transform.rotation = new Quaternion (0, 0, 0, 0);
					p.faceright = false;
					aux.x = 1.4f;
					aux.y = 1.4f;
					p.transform.localScale = aux;
					liberar = 0;
				}
			}
			else
			{
				if (this.tag == "punyo")
				{
					rigbod.AddForce(new Vector2 (-70f, 1f));
					SystemVar.SystemVar.vidaPlayer-=5;
					//Debug.Log ("GOLPEMANO");
					//Debug.Log (SystemVar.SystemVar.vidaPlayer);

					
				}
			}
		}

	}
	
}
