using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFish : MonoBehaviour {

	public Rigidbody2D fishRB;
	public Rigidbody2D fishObj;

	public Rigidbody2D fishRB2;
	public Rigidbody2D fishObj2;

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
			switch (Random.Range (0, 4)) 
			{
				case 1:
				{
					fishObj = Instantiate (fishRB, new Vector3 (-30, 0, 0), Quaternion.identity);
					FishAI fishScript = fishObj.GetComponent<FishAI> ();
					fishScript.pos = false;
					fishObj.GetComponent<SpriteRenderer> ().flipX = true;
					break;
				}

				case 2:
				{
					fishObj = Instantiate (fishRB, new Vector3 (30, 0, 0), Quaternion.identity);
					FishAI fishScript = fishObj.GetComponent<FishAI> ();
					fishScript.pos = true;
					break;
				}

				case 3:
				{
					fishObj2 = Instantiate (fishRB2, new Vector3 (Random.Range(-20,20), -30, 0), Quaternion.identity);
					break;
				}
			}
		}
	}
}
