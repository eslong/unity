using UnityEngine;
using System.Collections;

public class HurtPlayerOnContact : MonoBehaviour {

	public int damageToGive;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		// Trigger RespawnPlayer if the triggered collision is caused by the Player object
		if (other.name == "Player") {
			PlayerHealthManager.HurtPlayer(damageToGive);
			other.GetComponent<AudioSource>().Play();

			var player = other.GetComponent<PlayerBehaviour>();
			player.knockbackCount = player.knockbackLength;

			player.isKnockbackFromRight = (other.transform.position.x < transform.position.x);
		}
	}
}
