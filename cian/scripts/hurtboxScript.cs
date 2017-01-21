using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurtboxScript : MonoBehaviour {

    float desTimer = 7f;
    float desTick = 0f;
    public GameObject parent;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float myPosition = this.gameObject.transform.position.y;
        myPosition = parent.transform.position.y;
        this.transform.position = new Vector3(0.0f, myPosition, 0.0f);
        Debug.Log("position is" + myPosition.ToString());
        desTick += 1f;

        if (desTick >= desTimer)
        {
            Object.Destroy(this.gameObject);
        }
    }
}
