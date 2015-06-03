using UnityEngine;
using System.Collections;

public class Boss_creador_rayo : MonoBehaviour {
	public GameObject Rayo;
	public GameObject player;
	private bool ok;
	// Use this for initialization
	void Start () {
		//_prefBoss_crearayos = GameObject.FindGameObjectsWithTag("rayo");
		ok = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(SystemVar.SystemVar.rayos == true && !ok)
		{
			ok = true;
			InvokeRepeating("instanciarayo",0f,10f);
			//SystemVar.SystemVar.rayos = false;
		}
	}

	void instanciarayo()
	{
		Debug.Log ("rayo");
		Instantiate(Rayo,player.transform.position - new Vector3(0f, -0.4f, 0f),player.transform.rotation);
	}
}
