using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

	private bool isPlayerInZone;
	public string levelToLoad;
	public string levelTag;

	// Use this for initialization
	void Start () {
		isPlayerInZone = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxisRaw("Vertical") > 0 && isPlayerInZone) {
			PlayerPrefs.SetInt(levelTag, 1);
			SceneManager.LoadScene(levelToLoad);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.name == "Player") {
			isPlayerInZone = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.name == "Player") {
			isPlayerInZone = false;
		}
	}
}
