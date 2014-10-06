﻿using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	public float rotationSpeed = 10.0f;
	public Vector3 axis = Vector3.forward;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround (axis, rotationSpeed * Mathf.Deg2Rad * Time.deltaTime);
	}
}
