using UnityEngine;
using System.Collections;

public class HealthPickup : MonoBehaviour {

	public int healthToGive;

	public AudioSource pickupSoundEffect;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.GetComponent<PlayerBehaviour>() == null) {
			return;
		}

		PlayerHealthManager.HurtPlayer(-healthToGive);
		pickupSoundEffect.Play();
		Destroy(gameObject);
	}
}
