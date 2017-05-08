using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

	public string startLevel;
	public string info;

	public void NewGame(){
		Application.LoadLevel (startLevel);
	}

	public void moreInfo(){
		Application.LoadLevel (info);
	}

	public void QuitGame (){
		Application.Quit();
	}
}
