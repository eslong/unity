using UnityEngine;
using System.Collections;

public class CoinPickup : MonoBehaviour {

	public int coinValue;

	public AudioSource coinSoundEffect;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.GetComponent<PlayerBehaviour>() == null) {
			return;
		}

		ScoreManager.AddPoints(coinValue);
		coinSoundEffect.Play();
		Destroy(gameObject);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
