using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFish : MonoBehaviour {

	public Rigidbody2D fishRB;
	public Rigidbody2D fishObj;

	float startTime;
	bool spawn;
	int spawnChance;

	// Use this for initialization
	void Start () {
		spawnChance = 50;
		spawn = false;
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (startTime + 15 < Time.time) 
		{
			spawn = true;
		}

		//There is a one in SpawnChance* chance of a spawn
		if(Random.Range(0,spawnChance) == 1 && spawn == true)
		{
			switch (Random.Range (0, 3)) 
			{
				case 1:
				{
					fishObj = Instantiate (fishRB, new Vector3 (-30, 0, 0), Quaternion.identity);
					FishAI fishScript = fishObj.GetComponent<FishAI> ();
					fishScript.pos = false;
					break;
				}

				case 2:
				{
					fishObj = Instantiate (fishRB, new Vector3 (30, 0, 0), Quaternion.identity);
					FishAI fishScript = fishObj.GetComponent<FishAI> ();
					fishScript.pos = true;
					break;
				}
			}
		}
	}
}
