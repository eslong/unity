using UnityEngine;
using System.Collections;

public class LifePickup : MonoBehaviour {

	private LifeManager lifeManager;

	// Use this for initialization
	void Start () {
		lifeManager = FindObjectOfType<LifeManager>();
	}
	

	void OnTriggerEnter2D(Collider2D other) {
		if (other.name == "Player") {
			lifeManager.GiveLife();
			Destroy(gameObject);
		}
	}
}
