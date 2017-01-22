using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour {

	public float finalHeight;
	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Slides in title
		if (transform.position.y > finalHeight) 
		{
			transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
		}

		//Starts game when player hits enter
		if(Input.GetKeyDown( KeyCode.Return ))
		{
			SceneManager.LoadScene(1);
		}
	}
}
