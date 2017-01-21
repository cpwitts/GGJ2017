using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraParentScript : MonoBehaviour {

    public bool shake = false;
    float timer = 0f;
    float shaking = 0f;
    Vector2 ogPosition;
	// Use this for initialization
	void Start () {
        ogPosition = this.gameObject.transform.position;

    }
	
	// Update is called once per frame
	void Update () {

        shaking = (Random.Range(-.50f, .50f));
        if (shake)
        {
            this.gameObject.transform.position = new Vector2(shaking, shaking);
            if (timer < 3f)
            {
                timer += 1;
            }
            if (timer == 3f)
            {
                shake = false;
            }

        }
        else if (shake == false)
        {
            timer = 0f;
            this.gameObject.transform.position = ogPosition;
        }
    }
}
