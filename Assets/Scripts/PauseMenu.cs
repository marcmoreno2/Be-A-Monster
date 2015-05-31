using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	// Use this for initialization




	public bool isPaused;
	public GameObject pauseMenuCanvas;


	public void Resume()
	{
		isPaused = false;
	}

	public void Menu()
	{
		Application.LoadLevel ("Main_Menu");
	}
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isPaused) 
		{
			pauseMenuCanvas.SetActive (true);
			Time.timeScale=0f;
		} 
		else 
		{
			pauseMenuCanvas.SetActive(false);
			Time.timeScale =1f;
		}
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			isPaused=!isPaused;
		}
	}
}
