using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Transform cam;

	// Use this for initialization
	void Start ()
	{
	    cam = GameObject.Find("Cam").transform;
	    this.transform.rotation = cam.transform.rotation;

	}
	
	// Update is called once per frame
	void Update ()
	{
	    this.transform.rotation = Quaternion.Slerp(this.transform.rotation,cam.transform.rotation,0.1f*Time.time);

	}
}
