using UnityEngine;
using System.Collections;

public class DamagePlayerOnTrigger : MonoBehaviour {

	public float damageAmount = 1.0f;
	public float coolDownTime = 1.0f;

	private bool inCoolDown = false;

	void OnTriggerEnter(){
		if (!inCoolDown) {
			HealthManager.Instance.DamagePlayer (damageAmount);
			inCoolDown = true;
			Invoke ("Uncool", coolDownTime);
		}
	}

	void Uncool(){
		inCoolDown = false;
	}
}
