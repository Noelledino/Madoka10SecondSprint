using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

	public float startingTime;
	private Text timeText;

	// Use this for initialization
	void Start () {
		timeText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		startingTime -= Time.deltaTime;

		timeText.text = "" + Mathf.Round(startingTime);
	}
}
