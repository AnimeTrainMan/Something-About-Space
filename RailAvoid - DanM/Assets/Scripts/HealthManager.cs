using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour {

	ScoreManager score = new ScoreManager();
	public GameObject scoreObject;

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
	public float currentHealth;
	private float healthOriginalYScale;
	//public GameObject gib;
	public Color maxHealthColor = Color.green;
	public Color minHealthColor = Color.red;
	//GameObject Hurt = Instantiate(ExplosionHurt) as GameObject;
	//public ParticleSystem hurtParticle;

	public bool isDead = false;

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
		healthOriginalYScale = healthDisplay.localScale.y;

		scoreObject = GameObject.Find("$ScoreManager");
	}

	//void OnGUI(){
	//	GUILayout.Label ("HEALTH: " + currentHealth);
	//}
	
	public void DamagePlayer(float damageAmount){
		if (damageAmount < 0) {
			Debug.LogError("Cannot post a negative value to DmagePlayer. Please use HealPlayer instead.");
			return;
		}

		currentHealth -= damageAmount;
		healthDisplay.localScale = new Vector3 (healthDisplay.localScale.x, healthOriginalYScale * (currentHealth / maxHealth), healthDisplay.localScale.x);
		healthDisplay.GetComponentInChildren<Renderer>().material.color = Color.Lerp (minHealthColor, maxHealthColor, currentHealth);
		//hurtParticle.isPlaying = true;
		if (currentHealth <= 0.0f) {
			//Instantiate (gib,transform.position,Random.rotation);
			//Destroy (gameObject);
			//gameover/loselife
			currentHealth = 0;
			//healthDisplay.GetComponentInChildren<Renderer>.enabled = false;
			healthDisplay.localScale = new Vector3 (healthDisplay.localScale.x, healthOriginalYScale * 0, healthDisplay.localScale.x);
			//healthDisplay.render.material.color = Color.red;
		}
	}

	public void HealPlayer(float healAmount){
		if (healAmount < 0) {
			Debug.LogError("Cannot post a negative value to HealPlayer. Please use DamagePlayer instead.");
			return;
		}
		currentHealth += healAmount;
		healthDisplay.localScale = new Vector3 (healthDisplay.localScale.x, healthOriginalYScale * (currentHealth / maxHealth), healthDisplay.localScale.x);
		healthDisplay.GetComponentInChildren<Renderer>().material.color = Color.Lerp (minHealthColor, maxHealthColor, currentHealth / maxHealth);

		if (currentHealth > maxHealth) {
			currentHealth = maxHealth;
			healthDisplay.localScale = new Vector3 (healthDisplay.localScale.x, healthOriginalYScale * 1, healthDisplay.localScale.x);
			//healthDisplay.render.material.color = Color.green;
		}
	}

	// Update is called once per frame
	void Update () {
	
		if (currentHealth <= 0.0f)
		{
			isDead = true;
		}
		
		if (isDead == true && currentHealth <= 0.0f)
		{
			Debug.Log(currentHealth);
			Debug.Log("you died");
			Application.LoadLevel("gameOverScene");

		}

		//DISPLAY TEST
		/*if (Input.GetButtonDown ("Fire1"))
		{
			currentHealth -= 1;
			healthDisplay.localScale = new Vector3 (healthDisplay.localScale.x, healthOriginalYScale * (currentHealth / maxHealth), healthDisplay.localScale.x);
		}*/
	}
}
