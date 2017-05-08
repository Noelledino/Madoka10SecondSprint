using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

	public float startingTime;
	private Text timeText;

	public PauseMenu thePauseMenu;
	public GameObject GameOverScreen;
	public PlayerManager player;

	// Use this for initialization
	void Start () {
		timeText = GetComponent<Text> ();
		player = FindObjectOfType<PlayerManager> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (thePauseMenu.isActiveAndEnabled) {
			return;
		}
		startingTime -= Time.deltaTime;
		timeText.text = "" + Mathf.Round(startingTime);
		if (startingTime <= 0) {
			Time.timeScale = 0;
			GameOverScreen.SetActive (true);
			player.gameObject.SetActive (false);
		}


	}
}
