using UnityEngine;
using System.Collections;

public class Boss_brazos : MonoBehaviour {
	public GameObject jugador;
	private Player p;
	private int liberar;
	private Vector3 aux;
	private float timer;
	public bool atrapat;
	private Rigidbody2D rigbod;

	// Use this for initialization
	void Start () {

		p=jugador.GetComponent<Player> () as Player;
		aux = p.transform.localScale;
		rigbod = p.GetComponent<Rigidbody2D> ();
		timer = 0;
		atrapat = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (atrapat) {
			SystemVar.SystemVar.vidaPlayer-=0.5f;
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
				atrapat= false;
			}
		
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{

		if (other.tag == "Player" && tag == "Mano") {
			if (p.agarra) {
				other.transform.parent = this.transform;
				other.transform.position = other.transform.parent.position;
				
				aux = other.transform.localScale;
				aux.x = 1.4f;
				aux.y = 1.4f;
				other.transform.localScale = aux;
				
				Vector3 aux2 = other.transform.localPosition;
				aux2.x = -0.5f;
				aux2.y = 0.1f;
				other.transform.localPosition = aux2;
				
				rigbod.isKinematic = true;
				atrapat = true;



				//Debug.Log (SystemVar.SystemVar.vidaPlayer);

			}
		}
			else if (this.tag == "punyo" && other.tag == "Player")
				{
					rigbod.AddForce(new Vector2 (-70f, 1f));
					SystemVar.SystemVar.vidaPlayer-=5;
					Debug.Log(this.gameObject.name);
					Debug.Log ("GOLPEMANO");
					//Debug.Log (SystemVar.SystemVar.vidaPlayer);

		
		}

	}
	
}
