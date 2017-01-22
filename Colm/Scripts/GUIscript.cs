﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIscript : MonoBehaviour {

	//Style of the score text
	public GUIStyle scoreStyle;
	//Player score
	float score;
	//Score rouned to an int for clean display
	int displayedScore;
	//Is the game over?
	public bool gameOver;
	//Style for the game over font
	public GUIStyle endStyle;

	void Start () 
	{
		//Game is not over at start
		gameOver = false;
	}

	void Update () 
	{
		//Player gets points for not dying
		score += Time.deltaTime;
		displayedScore = (int)score;

		//Freeze time if the game is over
		if (gameOver) 
		{
			Time.timeScale = 0;
		}
	}

	void OnGUI()
	{
		//Displays score
		GUI.Label( new Rect(Screen.width / 1.8f, Screen.height / 1.1f, 200, 200), "Score: " + displayedScore, scoreStyle);

		//DIsplays gameOver message when the game ends
		if (gameOver) 
		{
			GUI.Label( new Rect(Screen.width / 5, Screen.height / 10, 400, 400), "GAME OVER\nYOUR SCORE: " + displayedScore + "\nPRESS ENTER TO RESTART", endStyle); 
		}
	}

	//Ends the game. To be called by other objects.
	public void endGame ()
	{
		gameOver = true;
	}

	public void addScore (float scoreToAdd)
	{
		score += scoreToAdd;
	}
}
