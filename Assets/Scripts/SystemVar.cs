using UnityEngine;
using System.Collections;

namespace SystemVar {
	
	public class SystemVar:MonoBehaviour
	{
		public GameObject boss;
		//public static float contCasa1=-1;
		//public static float contCasa2=-1;
		public static bool guardias=false, startboss=false, renderBoss=false, rayos=false;
		//public static Vector3 posPlayer;
		public static int contGuardias=0;
		public static float playerAtack = 100f, vidaPlayer=500f, score=0f, vidaBoss = 1000f;

		void Update(){
			if (startboss)
				boss.gameObject.SetActive (true);
		}

	}
}