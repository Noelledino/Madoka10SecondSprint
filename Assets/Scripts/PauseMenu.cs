using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public string mainMenu;
	public string restart;

	public bool isPaused;

	public GameObject pauseMenuCanvas;

	void Update () {
		if (isPaused) {
			pauseMenuCanvas.SetActive (true);
			Time.timeScale = 0f;
		} else {
			pauseMenuCanvas.SetActive (false);
			Time.timeScale = 1f;
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			isPaused = !isPaused;
		}

	}


	public void unPause(){
		isPaused = false;
	}

	public void RestartGame(){
		Application.LoadLevel (restart);
	}

	public void ReturnMenu (){
		Application.LoadLevel (mainMenu);
	}
}
