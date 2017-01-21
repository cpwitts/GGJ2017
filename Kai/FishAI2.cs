using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAI2 : MonoBehaviour {

	float jumpSpeed;

	// Use this for initialization
	void Start () {
		jumpSpeed = Random.Range (15, 20);
	}
	
	// Update is called once per frame
	void Update () {
		//Fish goes straight up
		//print (transform.position.y);

		transform.Translate (new Vector3 (0, jumpSpeed, 0) * Time.deltaTime);
		if (transform.position.y > 0) {
			jumpSpeed -= 20 * Time.deltaTime;
			print (1 * Time.deltaTime);
		}
	}
}
