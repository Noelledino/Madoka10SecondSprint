using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public int points;
	public Text pointsText;

	void Start () {

		Time.timeScale = 1;
	}

	void Update () {

		pointsText.text = ("" + points);
	}
}
