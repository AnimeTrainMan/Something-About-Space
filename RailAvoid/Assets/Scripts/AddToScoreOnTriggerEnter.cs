using UnityEngine;
using System.Collections;

public class AddToScoreOnTriggerEnter : MonoBehaviour {

	public int pointValue = 1;
	
	// Update is called once per frame
	void OnTriggerEnter() {
		ScoreManager.Instance.score += pointValue;
	}
}
