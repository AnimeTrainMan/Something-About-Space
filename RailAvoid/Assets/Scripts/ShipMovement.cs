using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour 
{

	public float movementSpeed = 10;
	public int invert = -1;//nega 1 for invert pos 1 for not


	void Start(){
		//Register for level changed events
		ScoreManager.Instance.LevelChanged += LevelChanged;
	}

	void OnDestroy(){
		ScoreManager.Instance.LevelChanged -= LevelChanged;
	}

	void OnDisable(){
		ScoreManager.Instance.LevelChanged -= LevelChanged;
	}

	// Update is called once per frame
	void Update () 
	{
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");

		Vector3 direction = new Vector3(horizontal,invert*vertical,0);
		Vector3 finalDirection = new Vector3(horizontal,invert*vertical,1.0f);
		transform.position += direction*movementSpeed*Time.deltaTime;
		//if (horizontal != 0 || vertical != 0) {
			transform.rotation = Quaternion.RotateTowards(transform.rotation,Quaternion.LookRotation(finalDirection),Mathf.Deg2Rad*180.0f);
		//}

		//Dash for other project
		/*if (Input.GetButton ("Fire2")) {
			movementSpeed = 20;
		} else {
			movementSpeed = 10;
		}*/
	}

	void LevelChanged(int newLevel){
		Debug.Log("ShipMovement: New Level Event Received! Level: " + newLevel);
	}
}
