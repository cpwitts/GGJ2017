using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParralaxScrolling : MonoBehaviour {

	public GameObject[] layers;
	public float[] parralaxStrengths;
	public float speed;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		for (int i = 0; i < layers.Length; i++) 
		{
			layers [i].transform.Translate (new Vector3 (parralaxStrengths [i] * speed * Time.deltaTime,0,0));
			if(layers[i].transform.position.x >= (15 * 2.38))
			{
				layers [i].transform.position = new Vector3 (0, 0, layers[i].transform.position.z);
			}
		}
	}
}
