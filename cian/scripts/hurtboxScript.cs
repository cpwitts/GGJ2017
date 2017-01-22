using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurtboxScript : MonoBehaviour {

    public GameObject dummyCamera;
    public GameObject Parent;
    public GameObject hurt;
    public Sprite left;
    public Sprite right;
    // Use this for initialization

    //GUIscript used to keep score
    public GUIscript score;


    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerMovement playerMove = Parent.GetComponent<playerMovement>();
        if(playerMove.direction == -1)
        {
            hurt.GetComponent<SpriteRenderer>().sprite = left;
        }
        if(playerMove.direction == 1)
        {
            hurt.GetComponent<SpriteRenderer>().sprite = right;
        }
        if (collision.gameObject.tag == "enemy")
        {
            cameraParentScript camReact = dummyCamera.GetComponent<cameraParentScript>();
            camReact.shake = true;
			if (collision.gameObject.GetComponent<FishAI> () != null) 
			{
				collision.gameObject.GetComponent<FishAI> ().kill ();
				collision.gameObject.GetComponent<FishAI> ().GetComponent<AudioSource> ().Play ();
			}
			else if (collision.gameObject.GetComponent<FishAI2> () != null) 
			{
				collision.gameObject.GetComponent<FishAI2> ().kill ();
				collision.gameObject.GetComponent<FishAI2> ().GetComponent<AudioSource> ().Play();
			}

			score.addScore (10);
        }
    }
}
