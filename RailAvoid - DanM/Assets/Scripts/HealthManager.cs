using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour {
	//SINGLETON
	private static HealthManager instance = null;
	public static HealthManager Instance
	{
		get{ return instance;}
	}
	void Awake(){
		if (instance != null && instance != this) {
						Destroy (this.gameObject);
						return;
		} else {
			instance = this;		
		}
		DontDestroyOnLoad (this.gameObject);
		gameObject.name = "$HealthManager";
	}
	//ENDSINGLETON

	public Transform healthDisplay;
	public float maxHealth = 10.0f;
	private float currentHealth;
	private float healthOriginalYScale;

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
		healthOriginalYScale = healthDisplay.localScale.y;
	}

	void OnGUI(){
		GUILayout.Label ("HEALTH: " + currentHealth);
	}
	
	public void DamagePlayer(float damageAmount){
		if (damageAmount < 0) {
			Debug.LogError("Cannot post a negative value to DmagePlayer. Please use HealPlayer instead.");
			return;
		}

		currentHealth -= damageAmount;
		healthDisplay.localScale = new Vector3 (healthDisplay.localScale.x, healthOriginalYScale * (currentHealth / maxHealth), healthDisplay.localScale.x);
		if (currentHealth < 0) {
			//gameover/loselife
			currentHealth = 0;
			healthDisplay.localScale = new Vector3 (healthDisplay.localScale.x, healthOriginalYScale * 0, healthDisplay.localScale.x);
		}
	}

	public void HealPlayer(float healAmount){
		if (healAmount < 0) {
			Debug.LogError("Cannot post a negative value to HealPlayer. Please use DamagePlayer instead.");
			return;
		}
		currentHealth += healAmount;
		healthDisplay.localScale = new Vector3 (healthDisplay.localScale.x, healthOriginalYScale * (currentHealth / maxHealth), healthDisplay.localScale.x);
		if (currentHealth > maxHealth) {
			currentHealth = maxHealth;
			healthDisplay.localScale = new Vector3 (healthDisplay.localScale.x, healthOriginalYScale * 1, healthDisplay.localScale.x);
		}
	}

	// Update is called once per frame
	void Update () {

		//DISPLAY TEST
		/*if (Input.GetButtonDown ("Fire1"))
		{
			currentHealth -= 1;
			healthDisplay.localScale = new Vector3 (healthDisplay.localScale.x, healthOriginalYScale * (currentHealth / maxHealth), healthDisplay.localScale.x);
		}*/
	}
}
