﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public int points;
	public Text pointsText;

	void Update () {

		pointsText.text = ("Points: " + points);
	}
}
