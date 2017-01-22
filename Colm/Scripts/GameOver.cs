/**
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 *  DO NOT USE, CODE DOESN'T DO ANYTHING IMPORTANT
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

	public GUIStyle endStyle;

	// Use this for initialization
	void Start () 
	{
		Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGui()
	{
		GUI.Label( new Rect(0,0, 400, 400), "GAME OVER", endStyle); 
	}
}
