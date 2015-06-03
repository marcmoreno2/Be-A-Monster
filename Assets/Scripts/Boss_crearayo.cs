using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class creador_rayo : MonoBehaviour {
	public GameObject Rayo;
	private GameObject[] _prefBoss_crearayos;
	// Use this for initialization
	void Start () {
		_prefBoss_crearayos = GameObject.FindGameObjectsWithTag("rayo");
	}
	
	// Update is called once per frame
	void Update () {
	
		if(SystemVar.SystemVar.rayos == true)
		{
			foreach(GameObject _GO in _prefBoss_crearayos)
			{
				Instantiate(Rayo,_GO.transform.position,_GO.transform.rotation);
			}
			SystemVar.SystemVar.rayos = false;
		}
	}
}
