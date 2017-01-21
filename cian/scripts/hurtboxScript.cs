using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurtboxScript : MonoBehaviour {

    public GameObject dummyCamera;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            cameraParentScript camReact = dummyCamera.GetComponent<cameraParentScript>();
            camReact.shake = true;
        }
    }
}
