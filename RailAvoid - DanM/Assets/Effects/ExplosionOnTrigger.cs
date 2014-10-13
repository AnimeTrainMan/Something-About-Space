using UnityEngine;
using System.Collections;

public class ExplosionOnTrigger : MonoBehaviour {
	
	void Start () {
		// You can use particleSystem instead of
		// gameObject.particleSystem.
		// They are the same, if I may say so
		particleSystem.emissionRate = 0;
	}
	
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			particleSystem.emissionRate = 1000;
		} else {
			particleSystem.emissionRate = 0;
		}
	}
}
