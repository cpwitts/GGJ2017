using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAI : MonoBehaviour {

	int speed;
	float jumpHeight;
	int fallSpeed;
	bool dead;//Is this fish dead or alive?

	//Left is false, Right is true
	public bool pos;
	bool jump;

	// Use this for initialization
	void Start () {
		jump = false;
		speed = Random.Range(5, 14);
		jumpHeight = Random.Range(15, 18);
		dead = false;
	}
	
	// Update is called once per frame
	void Update () {
		//print (transform.position.x);

		//Checks if it's spawned from left or right to determine the directon it will go
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

		//If the fish should jump when reaching a certian point
		if (transform.position.x > -5 && transform.position.x < 5) {
			jump = true;
		}
			
		if (jump == true) {
			jumpAnimation ();
		}
	}

	//Method for the jump animation
	void jumpAnimation()
	{
		transform.Translate (new Vector3 (0, jumpHeight, 0) * Time.deltaTime);
		jumpHeight -= 20 * Time.deltaTime; 

		//When fish is back into the water, stop falling.
		if (transform.position.y < -5 && jumpHeight < 1 && !dead) {
			jump = false;
		}
	}

	//Kills the fish
	public void kill()
	{
		gameObject.tag = "Untagged";
		GetComponent<SpriteRenderer>().flipY = true;
		dead = true;
	}
}
