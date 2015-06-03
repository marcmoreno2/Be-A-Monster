using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public GUISkin _button;

	public string Startgame;


	private GUISkin _default;
	void OnGUI () {
		
		
		//GUI.DrawTexture(new Rect (9, 21, Screen.width/2, Screen.height/2));
		
		_default = GUI.skin;
		
		GUI.skin = _button;
		
		
		GUI.matrix = Gui.matrixScale;
		
		/*if(GUI.Button (new Rect (450,300,200,50), "Start Game"))
		{
			Application.LoadLevel("Scene1");
		}
		if (GUI.Button (new Rect (450, 380, 200, 50), "Controls"))
		{
			Application.LoadLevel("Controls");	
		}
		if(GUI.Button (new Rect (450,460,200,50), "Quit"))
		{
			Application.Quit ();
		}*/
		
		GUI.matrix = Gui.matrix;
		GUI.skin = _default;
		
		
	}
	
	// Use this for initialization
	void StartGame () 
	{
		SystemVar.SystemVar.guardias = false;
		SystemVar.SystemVar.startboss = false;
		SystemVar.SystemVar.renderBoss=false;
		SystemVar.SystemVar.contGuardias=0;
		SystemVar.SystemVar.playerAtack = 100f;
		SystemVar.SystemVar.vidaPlayer = 500f;
		SystemVar.SystemVar.score = 0f;
		SystemVar.SystemVar.vidaBoss = 1000f;
		Application.LoadLevel(Startgame);

	}
	
	// Update is called once per frame
	void Exit () {
		Application.Quit ();
		
	}
}