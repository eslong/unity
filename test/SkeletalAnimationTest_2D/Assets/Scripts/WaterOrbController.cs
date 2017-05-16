using UnityEngine;
using System.Collections;

public class WaterOrbController : MonoBehaviour {

	public float speed;
	public Player_Water player;
	public float rotationSpeed;
	public float flightTime;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player_Water>();

		if (player.transform.localScale.x < 0) {
			speed = -speed;
			rotationSpeed = -rotationSpeed;
		}
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);

		GetComponent<Rigidbody2D>().angularVelocity = rotationSpeed;

		flightTime -= Time.deltaTime;
		if (flightTime <= 0) {
			Destroy(gameObject);
		}
	}
}
