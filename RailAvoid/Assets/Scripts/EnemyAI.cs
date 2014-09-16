using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public float targetDistance = 10.0f;
	public float enemySpeed = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		if (Vector3.Project (player.transform.position - transform.position, player.transform.forward).magnitude <= targetDistance) 
		{

			transform.position += Vector3.Project ((player.transform.position - transform.position).normalized, 
			    player.transform.forward) - Vector3.Project (player.transform.position - transform.position, player.transform.forward);

			//Vector3 newPosition = transform.position;

			//newPosition.z = player.transform.position.z + targetDistance;
			//transform.position = newPosition;
		} else {
			transform.position += transform.forward*enemySpeed*Time.deltaTime;
		}
	}
}
