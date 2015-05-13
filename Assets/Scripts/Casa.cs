using UnityEngine;
using System.Collections;
using SystemVar;

public class Casa : MonoBehaviour {

	public GameObject Slim;
	private string name;
	private float vida=300;
	private float timer;

	// Use this for initialization
	void Start () {
		timer = 0;

		if(this.gameObject.name == "prefCasa")
			name = "Casa1";
		else if(this.gameObject.name == "prefCasa 1")
			name = "Casa2";

		if(name == "Casa1")
		{
			SystemVar.SystemVar.contCasa1 = 0;
			GameObject _GO = Instantiate (Slim, this.transform.position, this.transform.rotation) as GameObject;
			Slim _S = _GO.GetComponent("Slim") as Slim;
			_S.name = name;
			SystemVar.SystemVar.contCasa1++;

		}else if(name == "Casa2")
		{
			SystemVar.SystemVar.contCasa2 = 0;
			GameObject _GO = Instantiate (Slim, this.transform.position, this.transform.rotation) as GameObject;
			Slim _S = _GO.GetComponent("Slim") as Slim;
			_S.name = name;
			SystemVar.SystemVar.contCasa2++;
		}


	}
	
	// Update is called once per frame
	void Update () {
		if(SystemVar.SystemVar.contCasa1==0 && name == "Casa1")
		{
			timer += Time.deltaTime;
			if(timer >= 4)
			{
				SystemVar.SystemVar.contCasa1 = 0;
				GameObject _GO = Instantiate (Slim, this.transform.position, this.transform.rotation) as GameObject;
				Slim _S = _GO.GetComponent("Slim") as Slim;
				_S.name = name;
				SystemVar.SystemVar.contCasa1++;
				timer = 0;
			}
		}else if(SystemVar.SystemVar.contCasa2==0 && name == "Casa2")
		{
			timer += Time.deltaTime;
			if(timer >= 4)
			{
				SystemVar.SystemVar.contCasa2 = 0;
				GameObject _GO = Instantiate (Slim, this.transform.position, this.transform.rotation) as GameObject;
				Slim _S = _GO.GetComponent("Slim") as Slim;
				_S.name = name;
				SystemVar.SystemVar.contCasa2++;
				timer = 0;
			}
		}

		if (vida <= 0)
		{
			Destroy(this.gameObject);
		}
	
	}

	void SlimS()
	{
		Instantiate (Slim, this.transform.position, this.transform.rotation);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Estrella")
		{
			vida-=10;
		}
	}
}
