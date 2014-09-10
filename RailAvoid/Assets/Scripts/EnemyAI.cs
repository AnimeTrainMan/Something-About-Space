using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public float targetDistance = 10.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		if ((player.transform.position - transform.position).magnitude < targetDistance) {
			Vector3 newPosition = transform.position;
			newPosition.z = player.transform.position.z + targetDistance;
			transform.position = newPosition;
		}
	}
}
