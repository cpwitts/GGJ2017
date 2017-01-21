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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "attack")
        {
            Object.Destroy(this.gameObject);
        }
    }
}
