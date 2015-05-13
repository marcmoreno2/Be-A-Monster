using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class creaGuardias : MonoBehaviour {
	public GameObject Guardia;
	private GameObject[] _prefCreatorGuards;
	// Use this for initialization
	void Start () {
		_prefCreatorGuards = GameObject.FindGameObjectsWithTag("Guardia");

	}
	
	// Update is called once per frame
	void Update () {
		/*if (SystemVar.SystemVar.guardias == true) 
		{
			InvokeRepeating("IGuardia",0f,0f);
			SystemVar.SystemVar.guardias=false;

		}*/
		if(SystemVar.SystemVar.guardias == true)
		{
			foreach(GameObject _GO in _prefCreatorGuards)
			{
				Instantiate(Guardia,_GO.transform.position,_GO.transform.rotation);
			}
			SystemVar.SystemVar.guardias = false;
		}
	}

	/*void IGuardia()
	{
		Instantiate(Guardia,this.transform.position,this.transform.rotation);
	}*/
}
