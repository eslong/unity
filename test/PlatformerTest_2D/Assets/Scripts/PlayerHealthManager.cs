using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour {

	public static int playerHealth;
	public int maxPlayerHealth;
	public bool isDead;
	private LifeManager lifeManager;

	//Text text;
	public Slider healthBar;

	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		//text = GetComponent<Text>();
		healthBar = GetComponent<Slider>();
		//playerHealth = maxPlayerHealth;
		playerHealth = PlayerPrefs.GetInt("PlayerCurrentHealth");
		levelManager = FindObjectOfType<LevelManager>();
		isDead = false;
		lifeManager = FindObjectOfType<LifeManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerHealth <= 0 && !isDead) {
			levelManager.RespawnPlayer();
			isDead = true;
			lifeManager.TakeLife();
		}

		if (playerHealth > maxPlayerHealth) playerHealth = maxPlayerHealth;

		//text.text = "" + playerHealth;
		healthBar.value = playerHealth;
	}

	public static void HurtPlayer(int damage) {
		playerHealth -= damage;
		if (playerHealth <= 0) playerHealth = 0;
		PlayerPrefs.SetInt("PlayerCurrentHealth", playerHealth);
	}

	public void PlayerFullHealth() {
		playerHealth = maxPlayerHealth;
		PlayerPrefs.SetInt("PlayerCurrentHealth", PlayerPrefs.GetInt("PlayerMaxHealth"));
	}

	public void KillPlayer() {
		playerHealth = 0;
		PlayerPrefs.SetInt("PlayerCurrentHealth", playerHealth);
	}
}
