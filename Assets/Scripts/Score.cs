using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {


	private Text score;

	// Use this for initialization
	void Start () {
		score = GetComponent<Text> ();
		//boss = FindObjectOfType<Boss> ();
	}
	
	// Update is called once per frame
	void Update () {
		score.text = "Score: " + SystemVar.SystemVar.score.ToString ();
	}
}
