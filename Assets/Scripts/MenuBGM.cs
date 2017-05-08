using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBGM : MonoBehaviour {

	static bool AudioBegin = false; 

	void Awake()

	{
		if (!AudioBegin) {
			AudioSource audio = GetComponent<AudioSource> ();
			audio.Play ();
			DontDestroyOnLoad (gameObject);
			AudioBegin = true;
		} 
	}
	void Update () {
		if(Application.loadedLevelName == "Level1")
		{
			AudioSource audio = GetComponent<AudioSource> ();
			audio.Stop();
			AudioBegin = false;
		}
	}
}