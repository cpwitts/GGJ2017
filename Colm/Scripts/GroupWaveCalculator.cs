using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupWaveCalculator : MonoBehaviour 
{
	//Variable used for calculations only
	public float x = 0;

	//How high the waves go
	public float roughness = 1;

	//The speed the waves travel
	public float speed = 1;

	//Used for rotation calculation
	public float[] prevX = new float[7];
	public float[] prevY = new float[7];
	public float slope;
	public float yOffset;

	//Changes the width of the waves
	public float xOffset;

	//Used for accessung wave hitboxes
	public float midpoint;

	//How fast the waves become more turbulant
	public float speedOfGrowth;

	//The wave hitboxes
	public Rigidbody2D[] waves = new Rigidbody2D[7];

	void Start()
	{
		//Initialise the necessary variables
		midpoint = (waves.Length - 1) / 2;
		for (int i = 0; i < waves.Length; i++) 
		{
			prevX[i] = x + xOffset * (i - midpoint);
			prevY[i] = waves[i].position.y + yOffset;
		}
	}
		
	void Update () 
	{
		//Reset X after a cycle, keeps x within reasonable range
		if (x >= 2 * Mathf.PI) 
		{
			x = 0;
			prevX[1] = 0;
		}

		//Calculate movement and increase waves each frame
		moveToNextHeight ();
		calcRotation ();
		roughness += (speedOfGrowth* Time.deltaTime);
		speed += (speedOfGrowth * Time.deltaTime);
	}

	void FixedUpdate()
	{
		//Update prev values
		for (int i = 0; i < waves.Length; i++) 
		{
			prevX[i] = x + xOffset * (i - midpoint);
			prevY[i] = waves[i].position.y + yOffset;
		}
	}

	//Calculates height of hitbox based on the wave and the hitboxes position within that wave
	void moveToNextHeight()
	{
		x += speed * Time.deltaTime;
		for (int i = 0; i < waves.Length; i++) 
		{
			waves[i].position = new Vector3(waves[i].position.x,  (roughness * Mathf.Sin(x + xOffset * (i - midpoint))) + yOffset, 0);
		}
	}
		
	//Calculates rotation of hitbox based on the wave and the hitboxes position within that wave
	void calcRotation()
	{
		for (int i = 0; i < waves.Length; i++) 
		{
			slope = (waves[i].position.y + yOffset - prevY[i]) / (x + xOffset * (i - midpoint) - prevX[i]);
			waves[i].MoveRotation (Mathf.Atan (slope) * Mathf.Rad2Deg);
		}
	}
}


