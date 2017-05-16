﻿using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {

	public LevelManager levelManager;

	// Use this for initialization
	void Start () {
		// Get LevelManager on current scene
		levelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		// Trigger RespawnPlayer if the triggered collision is caused by the Player object
		if (other.name == "Player") {
			levelManager.RespawnPlayer();
		}
	}
}
