using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public string levelSelect;
	public string mainMenu;

	public bool isPaused;
	public GameObject pauseMenuCanvas;

	void Update() {
		if (isPaused) {
			pauseMenuCanvas.SetActive(true);
			Time.timeScale = 0f;
		} else {
			pauseMenuCanvas.SetActive(false);
			Time.timeScale = 1f;
		}

		if (Input.GetKeyDown(KeyCode.Escape)) {
			isPaused = !isPaused;
		}
	}

	public void ResumeGame() {
		isPaused = false;
	}

	public void LevelSelect() {
		SceneManager.LoadScene(levelSelect);
	}

	public void QuitToMain() {
		SceneManager.LoadScene(mainMenu);
	}
}
