using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurtFlashScript : MonoBehaviour {

    float tick = 0f;
    float tickTotal = 2f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        tick += 1f;
        if(tick >= tickTotal)
        {
            Object.Destroy(this.gameObject);
        }
	}
}
