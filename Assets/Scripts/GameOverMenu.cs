using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MonoBehaviour {


	public string mainMenu;
	public string restart;


	public void RestartGame(){
		Time.timeScale = 1;
		Application.LoadLevel (restart);
	}

	public void ReturnMenu (){
		Time.timeScale = 1;
		Application.LoadLevel (mainMenu);
	}
}
