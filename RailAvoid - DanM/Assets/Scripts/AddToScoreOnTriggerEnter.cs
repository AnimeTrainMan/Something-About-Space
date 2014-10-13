using UnityEngine;
using System.Collections;

public class AddToScoreOnTriggerEnter : MonoBehaviour {
	MoveForward instance = new MoveForward();
	public int pointValue = 1;
	
	// Update is called once per frame
	void OnTriggerEnter() {
		ScoreManager.Instance.score += pointValue;
	}
}
