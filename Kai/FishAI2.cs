using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAI2 : MonoBehaviour {

	float jumpSpeed;
	bool dead;


	// Use this for initialization
	void Start () {
		jumpSpeed = Random.Range (15, 20);
		dead = false;
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

		if (transform.position.y < -20 && jumpSpeed < 1) {
			Destroy (this.gameObject);
		}
	}

	public void kill()
	{
		gameObject.tag = "Untagged";
		GetComponent<SpriteRenderer>().flipY = true;
		dead = true;
	}
}
