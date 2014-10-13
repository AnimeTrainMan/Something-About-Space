using UnityEngine;
using System.Collections;

public class bgMover : MonoBehaviour 
{
	GameObject bgPlanes;
	float bgX;
	float bgY;
	bool checker = false;
	public float bgScrollRate = 8;

	// Use this for initialization
	void Start () 
	{
		bgPlanes = GameObject.Find("bgPlane");
		bgX = bgPlanes.transform.position.x;
		bgY = bgPlanes.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Debug.Log(bgY);
		transform.Translate(Vector3.up * Time.deltaTime / bgScrollRate, Space.World);
	}
}
