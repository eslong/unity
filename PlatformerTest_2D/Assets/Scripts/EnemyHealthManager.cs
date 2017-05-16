using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour {

	public int enemyHealth;
	public GameObject deathEffect;
	public int enemyPointsValue;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (enemyHealth <= 0) {
			Instantiate(deathEffect, transform.position, transform.rotation);
			ScoreManager.AddPoints(enemyPointsValue);
			Destroy(gameObject);
		}
	}

	public void GiveDamage(int damage) {
		enemyHealth -= damage;
		GetComponent<AudioSource>().Play();
	}
}
