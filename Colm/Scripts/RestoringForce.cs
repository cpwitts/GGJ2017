/**
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * DO NOT USE, VERY BAD AND BROKEN
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoringForce : MonoBehaviour {

	public float criticalAngle;
	public float restoringStrength;
	public Rigidbody2D rb;
	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		print (transform.rotation.z * Mathf.Rad2Deg * 2);

		if (transform.rotation.z * Mathf.Rad2Deg * 2 > criticalAngle) 
		{
			transform.position = transform.position + (new Vector3(0,120,0) * Time.deltaTime);
			rb.MoveRotation(transform.rotation.z - (restoringStrength * Time.deltaTime));
			print ("restoring");
		}

		if (transform.rotation.z * Mathf.Rad2Deg * 2 < -criticalAngle) 
		{
			transform.position = transform.position + (new Vector3(0,120,0) * Time.deltaTime);
			rb.MoveRotation(transform.rotation.z + (restoringStrength * Time.deltaTime));
			print ("restoring");		
		}
	}
}
