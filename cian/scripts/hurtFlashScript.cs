using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurtFlashScript : MonoBehaviour {

    public GameObject flash;
    float tick;
    float tickTotal = 2f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        tick += Time.deltaTime * 9;
        flash.GetComponent<Renderer>().material.color = new Vector4(flash.GetComponent<Renderer>().material.color.r, flash.GetComponent<Renderer>().material.color.g, flash.GetComponent<Renderer>().material.color.b, flash.GetComponent<Renderer>().material.color.a - tick);
        if(tick >= tickTotal)
        {
            Object.Destroy(flash);
        }
        
	}
}
