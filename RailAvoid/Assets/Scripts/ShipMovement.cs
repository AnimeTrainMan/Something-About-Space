using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour 
{

	public Vector2 movementSpeed = Vector2.one;
	public int invert = -1;//nega 1 for invert pos 1 for not
	public float angleChangeSpeed = 120.0f;
	//public float angleChangeSpeed = 120.0f;

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
		float horizontal = Input.GetAxis ("Horizontal")*movementSpeed.x;
		float vertical = Input.GetAxis ("Vertical")*movementSpeed.y;

		Vector3 direction = new Vector3(horizontal,invert*vertical,0);
		Vector3 finalDirection = new Vector3(horizontal,invert*vertical,10.0f);
		transform.position += direction*/*movementSpeed**/Time.deltaTime;
		//if (horizontal != 0 || vertical != 0) {
		transform.rotation = Quaternion.RotateTowards(transform.rotation,Quaternion.LookRotation(finalDirection),Mathf.Deg2Rad*angleChangeSpeed);
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
