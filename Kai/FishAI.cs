using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAI : MonoBehaviour {

	int speed;
	int jumpHeight;
	int fallSpeed;

	//Left is false, Right is true
	public bool pos;
	bool jump;

	// Use this for initialization
	void Start () {
		jump = false;
		speed = Random.Range(5, 14);
		jumpHeight = Random.Range(15, 18);
	}
	
	// Update is called once per frame
	void Update () {
		print (transform.position.x);
		if (pos == true) {
			transform.Translate (new Vector3 (-speed, 0, 0) * Time.deltaTime);
			if (transform.position.x < -30) {
				Destroy (this.gameObject);
			}
		} else {
			transform.Translate (new Vector3 (speed, 0, 0) * Time.deltaTime);
			if (transform.position.x > 30) {
				Destroy (this.gameObject);
			}
		}

		if (transform.position.x > -5 && transform.position.x < 5) {
			jump = true;
		}
			
		if (jump == true) {
			jumpAnimation ();
		}
	}

	void jumpAnimation()
	{
		transform.Translate (new Vector3 (0, jumpHeight, 0) * Time.deltaTime);
		jumpHeight -= 1; 

		if (transform.position.y < -5 && jumpHeight < 1) {
			jump = false;
		}
	}
}
