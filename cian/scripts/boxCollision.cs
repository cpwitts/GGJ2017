using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxCollision : MonoBehaviour {

    public GameObject parent;
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "ground")
        {
            playerMovement playability = parent.GetComponent<playerMovement>();
            playability.grounded = true;
            Debug.Log(playability.grounded.ToString());
        }

    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "ground")
        {
            playerMovement playability = parent.GetComponent<playerMovement>();
            playability.grounded = false;
            Debug.Log(playability.grounded.ToString());
        }

    }
}
