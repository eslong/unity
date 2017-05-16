﻿using UnityEngine;
using System.Collections;

public class EnemyStarController : MonoBehaviour {

	public float speed;
	public PlayerBehaviour player;
	public GameObject impactEffect;
	public float rotationSpeed;
	public int ninjaStarDamage;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerBehaviour>();

		if (player.transform.position.x < transform.position.x) {
			speed = -speed;
			rotationSpeed = -rotationSpeed;
		}
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);

		GetComponent<Rigidbody2D>().angularVelocity = rotationSpeed;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.name == "Player") {
			PlayerHealthManager.HurtPlayer(ninjaStarDamage);
		}

		Instantiate(impactEffect, transform.position, transform.rotation);
		Destroy(gameObject);
	}
}
