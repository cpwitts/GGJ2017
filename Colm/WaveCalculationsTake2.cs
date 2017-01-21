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

	void Start()
	{
		prevX = x;
		prevY = transform.position.y;
	}
	// Update is called once per frame
	void Update () 
	{
		if (x >= 2 * Mathf.PI) 
		{
			x = 0;
		}

		if (x == 0) 
		{
			calcNewRoughness ();
		}
		moveToNextHeight ();
		calcRotation ();
	}

	void moveToNextHeight()
	{
		prevX = x;
		prevY = transform.position.y;
		x += speed * Time.deltaTime;
		transform.position = new Vector3(transform.position.x,  (roughness * Mathf.Sin(x)) - 1f, 0);

	}

	void calcNewRoughness()
	{
		roughness = Random.Range (1.0f, 4.0f);
	}

	void calcRotation()
	{
		slope = (transform.position.y - prevY) / (x - prevX);

		if (slope > 0) 
		{
			transform.rotation = new Quaternion (0, 0, Mathf.Atan (slope), 1);
		} 

		else 
		{
			transform.rotation = new Quaternion (0, 0, -Mathf.Atan (slope), 1);
		}
	}
}


