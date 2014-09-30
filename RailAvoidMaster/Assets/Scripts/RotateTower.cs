using UnityEngine;
using System.Collections;

public class RotateTower : MonoBehaviour
{
	public float rotationSpeed = 10.0f;
	
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.RotateAround(transform.forward,Input.GetAxis("Horizontal")*rotationSpeed*Mathf.Deg2Rad*Time.deltaTime);
	}
}
