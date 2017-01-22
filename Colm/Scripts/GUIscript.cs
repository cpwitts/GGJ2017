using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIscript : MonoBehaviour {

	public GUIStyle scoreStyle;
	float score;
	int displayedScore;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		score += Time.deltaTime;
		displayedScore = (int)score;
	}

	void OnGUI()
	{
		GUI.Label( new Rect(Screen.width / 1.8f, Screen.height / 1.1f, 200, 200), "Score: " + displayedScore, scoreStyle); 
	}
}
