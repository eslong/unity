using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour {

	//public int startingLives;
	private int currentLives;

	private Text text;

	public GameObject gameOverScreen;
	public PlayerBehaviour player;

	public string mainMenu;
	public float gameOverDelay;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();

		currentLives = PlayerPrefs.GetInt("PlayerCurrentLives");
		player = FindObjectOfType<PlayerBehaviour>();
	}
	
	// Update is called once per frame
	void Update () {
		if (currentLives <= 0) {
			currentLives = 0;
			gameOverScreen.SetActive(true);
			player.gameObject.SetActive(false);
		}

		text.text = "x " + currentLives;

		if (gameOverScreen.activeSelf) {
			gameOverDelay -= Time.deltaTime;
		}

		if (gameOverDelay < 0) {
			SceneManager.LoadScene(mainMenu);
		}
	}

	public void GiveLife() {
		currentLives++;
		PlayerPrefs.SetInt("PlayerCurrentLives", currentLives);
	}

	public void TakeLife() {
		currentLives--;
		PlayerPrefs.SetInt("PlayerCurrentLives", currentLives);
	}
}
