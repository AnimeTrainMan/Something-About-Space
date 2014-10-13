using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public float targetDistance = 10.0f;
	public float enemySpeed = 0.0f;
	public float delay = 0.0f;
	public float maxTime = 600.0f;
	//private bool wallCheck = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		GameObject plane = GameObject.FindGameObjectWithTag ("Player");


		if(delay >= maxTime){
			transform.position += transform.forward*enemySpeed*Time.deltaTime;
		}else	if (transform.position.z - plane.transform.position.z <= targetDistance) {
			Vector3 newPosition = transform.position;
			newPosition.z = plane.transform.position.z + targetDistance;
			transform.position=newPosition;
			delay++;


		}
		/*if (Vector3.Project (plane.transform.position - transform.position, plane.transform.forward).magnitude <= targetDistance) 
		{
			transform.position += Vector3.Project ((plane.transform.position - transform.position).normalized, 
			    plane.transform.forward) - Vector3.Project (plane.transform.position - transform.position, plane.transform.forward);

			//Vector3 newPosition = transform.position;

			//newPosition.z = player.transform.position.z + targetDistance;
			//transform.position = newPosition;
		}*/ else {
			transform.position += transform.forward*enemySpeed*Time.deltaTime;
		}



	}
}
