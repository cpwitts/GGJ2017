using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupWaveCalculator : MonoBehaviour 
{
	public float x = 0;
	public float roughness = 1;
	public float speed = 1;
	public float[] prevX = new float[7];
	public float[] prevY = new float[7];
	public float slope;
	public float yOffset;
	public float xOffset;
	public float midpoint;
	public float speedOfGrowth;
	public Rigidbody2D[] waves = new Rigidbody2D[7];

	void Start()
	{
		midpoint = (waves.Length - 1) / 2;
		for (int i = 0; i < waves.Length; i++) 
		{
			prevX[i] = x + xOffset * (i - midpoint);
			prevY[i] = waves[i].position.y + yOffset;
		}
	}
	// Update is called once per frame
	void Update () 
	{
		if (x >= 2 * Mathf.PI) 
		{
			x = 0;
			prevX[1] = 0;
		}

		if (x == 0) 
		{
			calcNewRoughness ();
		}
		moveToNextHeight ();
		calcRotation ();
		roughness += (speedOfGrowth* Time.deltaTime);
		speed += (speedOfGrowth * Time.deltaTime);
	}

	void FixedUpdate()
	{
		for (int i = 0; i < waves.Length; i++) 
		{
			prevX[i] = x + xOffset * (i - midpoint);
			prevY[i] = waves[i].position.y + yOffset;
		}
	}

	void moveToNextHeight()
	{
		x += speed * Time.deltaTime;
		for (int i = 0; i < waves.Length; i++) 
		{
			waves[i].position = new Vector3(waves[i].position.x,  (roughness * Mathf.Sin(x + xOffset * (i - midpoint))), 0);
		}
	}

	void calcNewRoughness()
	{
		//roughness = Random.Range (1f, 4.0f);
	}

	void calcRotation()
	{
		for (int i = 0; i < waves.Length; i++) 
		{
			slope = (waves[i].position.y + yOffset - prevY[i]) / (x + xOffset * (i - midpoint) - prevX[i]);
			waves[i].MoveRotation (Mathf.Atan (slope) * Mathf.Rad2Deg);
		}
	}
}


