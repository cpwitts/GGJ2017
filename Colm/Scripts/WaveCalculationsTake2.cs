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
 * DO NOT USE, BETTER CODE HAS BEEN WRITTEN
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

public class WaveCalculationsTake2 : MonoBehaviour 
{
	public float x = 0;
	public float roughness = 1;
	public float speed = 1;
	public float prevX;
	public float prevY;
	public float slope;
	public float offset;

	void Start()
	{
		prevX = x;
		prevY = transform.position.y + offset;
	}
	// Update is called once per frame
	void Update () 
	{
		if (x >= 2 * Mathf.PI) 
		{
			x = 0;
			prevX = 0;
		}

		if (x == 0) 
		{
			calcNewRoughness ();
		}
		moveToNextHeight ();
		calcRotation ();
	}

	void FixedUpdate()
	{
		prevX = x;
		prevY = transform.position.y + offset;
		print (transform.position.y + " - " + prevY);
	}

	void moveToNextHeight()
	{
		x += speed * Time.deltaTime;
		transform.position = new Vector3(transform.position.x,  (roughness * Mathf.Sin(x)) - 1f, 0);
	}

	void calcNewRoughness()
	{
		roughness = Random.Range (1.0f, 4.0f);
	}

	void calcRotation()
	{
		slope = (transform.position.y + offset - prevY) / (x - prevX);

		GetComponent<Rigidbody2D>().MoveRotation (Mathf.Atan (slope) * -Mathf.Rad2Deg);
	}
}


