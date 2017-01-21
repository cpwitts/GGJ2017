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
 * DO NOT USE, VERY BAD AND BROKEN
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

public class WaveCalculations : MonoBehaviour 
{
	public bool peak = true;
	public bool transition = false;
	public float nextHeight = 0f;
	public float lastHeight = 0f;
	public float speed = 3;
	public float offset = 0f;
	public float x = 0;

	// Update is called once per frame
	void Update () 
	{
		if (transform.position.y >= -0.2 && transform.position.y <= 0.2) 
		{
			if (!transition) 
			{
				transition = true;

				if (peak) 
				{
					peak = false;
				} 

				else 
				{
					peak = true;
				}

				lastHeight = nextHeight;
				x = 0;
				calcNewNextHeight ();
			}
		} 

		else if (transition) 
		{
			transition = false;
		}

		moveToNextHeight ();
	}

	void calcNewNextHeight()
	{
		if(peak)
		{
			nextHeight = Random.Range(3.0f, 4.0f);
		}

		else
		{
			nextHeight = Random.Range(-1.0f, 0f);
		}
	}

	void moveToNextHeight()
	{

		x += 1 * Time.deltaTime;
		if(!peak)
		{
			transform.position = new Vector3(transform.position.x,  ((x-2) * (x - Mathf.Sqrt(Mathf.Abs(nextHeight)))) - nextHeight, 0);



			//transform.Translate(new Vector3(0, speed, 0) * Time.deltaTime);
		}

		else if(peak)
		{


			transform.position = new Vector3(transform.position.x, (-(x-2) * (x - Mathf.Sqrt(Mathf.Abs(nextHeight)))) + nextHeight, 0);

			//transform.Translate(new Vector3(0, speed, 0) * Time.deltaTime);
		}
	}
}


