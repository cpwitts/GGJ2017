using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dummyScript : MonoBehaviour {

    public GameObject dummy;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        dummy.transform.Translate(new Vector3(-.000003f,0f,0f));
	}
}
