using UnityEngine;
using System.Collections;

public class LadderZone : MonoBehaviour {

	private PlayerBehaviour player;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerBehaviour>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.name == "Player") {
			player.isOnLadder = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.name == "Player") {
			player.isOnLadder = false;
		}
	}
}
