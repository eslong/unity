using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string startLevel;
	public string levelSelect;
	public int playerLives;
	public int playerHealth;
	public string startingLevelTag;

	public void NewGame() {
		PlayerPrefs.SetInt("PlayerCurrentLives", playerLives);
		PlayerPrefs.SetInt("PlayerCurrentScore", 0);
		PlayerPrefs.SetInt("PlayerCurrentHealth", playerHealth);
		PlayerPrefs.SetInt("PlayerMaxHealth", playerHealth);

		PlayerPrefs.SetInt(startingLevelTag, 1);
		PlayerPrefs.SetInt("PlayerLevelSelectPosition", 0);
		SceneManager.LoadScene(startLevel);
	}

	public void LevelSelect() {
		PlayerPrefs.SetInt("PlayerCurrentLives", playerLives);
		PlayerPrefs.SetInt("PlayerCurrentScore", 0);
		PlayerPrefs.SetInt("PlayerCurrentHealth", playerHealth);
		PlayerPrefs.SetInt("PlayerMaxHealth", playerHealth);

		PlayerPrefs.SetInt(startingLevelTag, 1);
		if (!PlayerPrefs.HasKey("PlayerLevelSelectPosition")) {
			PlayerPrefs.SetInt("PlayerLevelSelectPosition", 0);
		}
		SceneManager.LoadScene(levelSelect);
	}

	public void QuitGame() {
		Application.Quit();
	}
}
