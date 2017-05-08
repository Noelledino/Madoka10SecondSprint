using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public string mainMenu;
	public string restart;

	public void unPause(){
	}

	public void RestartGame(){
		Application.LoadLevel (restart);
	}

	public void ReturnMenu (){
		Application.LoadLevel (mainMenu);
	}
}
