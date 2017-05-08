using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

	public string startLevel;
	public string info;

	void Start () {
		Time.timeScale = 1;
	}

	public void NewGame(){
		Application.LoadLevel (startLevel);
	}

	public void moreInfo(){
		Application.LoadLevel (info);
	}

	public void back(){
		Application.LoadLevel ("titleMenu");
	}

	public void creditView(){
		Application.LoadLevel ("credits");
	}

	public void howToPlay(){
		Application.LoadLevel ("howToPlay");
	}

	public void QuitGame (){
		Application.Quit();
	}
}
