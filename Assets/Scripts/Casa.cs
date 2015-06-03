using UnityEngine;
using System.Collections;
using SystemVar;

public class Casa : MonoBehaviour {

	public GameObject Slim;
	private string name;
	public float vida;
	private float timer;
	public bool spawn, death;
	private Slim _S;
	private Animator anim;
	private AudioSource[] au;
	// Use this for initialization
	void Start () {
		vida = 1500;
		timer = 0;
		spawn = false;
		death = false;
		name = this.gameObject.name;
		GameObject _GO = Instantiate (Slim, this.transform.position - new Vector3(1f, 1.5f,0f), this.transform.rotation) as GameObject;
		_S = _GO.GetComponent ("Slim") as Slim;
		_S.deathC = false;
		_S.name = name;
		_S.deathC = false;
		anim = GetComponent<Animator> ();
		au = GetComponents<AudioSource> ();
		//_S.transform.parent=transform;

	}
	
	// Update is called once per frame
	void Update () {
		if (spawn && timer >= 4) {
			GameObject _GO = Instantiate (Slim, this.transform.position - new Vector3(1f, 1.5f,0f), this.transform.rotation) as GameObject;
			_S = _GO.GetComponent ("Slim") as Slim;
			_S.deathC = false;
			_S.name = name;
			//_S.transform.parent=transform;
			timer = 0;
			spawn = false;

		} else if (spawn && timer <4)
			timer += Time.deltaTime;

		if (vida <= 0)
		{
			death = true;
			anim.SetBool("muerte",true);
			//Destroy(gameObject, 0.2f);
		}
		spawn = _S.deathC;
	}
	void destroy()
	{
		Destroy (gameObject);
	}

	void PlaySoudCasaHit()
	{
		au [1].Play ();
	}

	void PlaySoudCasaDestroy()
	{
		au [0].Play ();
	}

	void acabaAni()
	{
		anim.SetBool("golpe", false);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Arma player")
		{
			anim.SetBool("golpe", true);	
			vida-=SystemVar.SystemVar.playerAtack;
		}
	}
	void OnDestroy()
	{
		//au [0].Play ();
		SystemVar.SystemVar.score += 100;
	}
}
