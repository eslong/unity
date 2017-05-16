using UnityEngine;
using System.Collections;

public class Checkpoints : MonoBehaviour {

	public LevelManager levelManager;

	// Use this for initialization
	void Start () {
		// Get current scene's LevelManager
		levelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		// Set currentCheckpoint to gameObject (current object) once Player collides with it
		if (other.name == "Player") {
			levelManager.currentCheckpoint = gameObject;
		}
	}
}
