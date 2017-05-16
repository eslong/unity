using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

	public float startingTime;
	public float countingTime;
	private Text text;

	private PauseMenu pauseMenu;

	public GameObject gameOverScreen;
	public PlayerBehaviour player;
	private PlayerHealthManager health;

	// Use this for initialization
	void Start () {
		countingTime = startingTime;
		text = GetComponent<Text>();
		pauseMenu = FindObjectOfType<PauseMenu>();
		//player = FindObjectOfType<PlayerBehaviour>();
		health = FindObjectOfType<PlayerHealthManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (pauseMenu.isPaused) {
			return;
		}

		countingTime -= Time.deltaTime;
		if (countingTime <= 0) {
			countingTime = 0;

			health.KillPlayer();
			//gameOverScreen.SetActive(true);
			//player.gameObject.SetActive(false);
		}
		text.text = "" + Mathf.Round(countingTime);
	}

	public void ResetTime() {
		countingTime = startingTime;
	}
}
