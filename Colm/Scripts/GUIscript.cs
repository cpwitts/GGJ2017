using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIscript : MonoBehaviour {

	//Style of the score text
	public GUIStyle scoreStyle;
    public GUIStyle healthStyle;
    public GameObject player;
	//Player score
	float score;
    //Score rouned to an int for clean display
    int gameHealth;
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
        //health
        playerMovement playMove = player.GetComponent<playerMovement>();
        gameHealth = (int)playMove.health;
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
        GUI.Label(new Rect(Screen.width / 1.2f, Screen.height / 1.1f, 200, 200), "health: " + gameHealth, healthStyle);
        //DIsplays gameOver message when the game ends
        if (gameOver) 
		{
			GUI.Label( new Rect(0, 0, Screen.width, Screen.height- Screen.height/3), "GAME OVER\nYOUR SCORE: " + displayedScore + "\nPRESS ENTER TO RESTART", endStyle); 
		}
	}

	//Ends the game. To be called by other objects.
	public void endGame ()
	{
		gameOver = true;
		GameObject.Find ("bgm").GetComponent<AudioSource> ().Stop ();
		GetComponent<AudioSource> ().Play ();
	}

	//Adds a given value to the score
	public void addScore (float scoreToAdd)
	{
		score += scoreToAdd;
	}
}
