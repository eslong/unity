using UnityEngine;
using System.Collections;

public class EnemyShootController : MonoBehaviour {

	public float playerRange;
	public GameObject enemyStar;
	public PlayerBehaviour player;
	public Transform shootPoint;
	public float shotDelay;
	private float shotCounter;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerBehaviour>();

		shotCounter = shotDelay;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawLine(new Vector3(transform.position.x - playerRange, transform.position.y, transform.position.z),
						new Vector3(transform.position.x + playerRange, transform.position.y, transform.position.z));

		shotCounter -= Time.deltaTime;

		if (transform.localScale.x < 0 && 
			player.transform.position.x > transform.position.x && 
			player.transform.position.x < transform.position.x + playerRange &&
			shotCounter <= 0) {
			Instantiate(enemyStar, shootPoint.position, shootPoint.rotation);
			shotCounter = shotDelay;
		}

		if (transform.localScale.x > 0 && 
			player.transform.position.x < transform.position.x && 
			player.transform.position.x > transform.position.x - playerRange &&
			shotCounter <= 0) {
			Instantiate(enemyStar, shootPoint.position, shootPoint.rotation);
			shotCounter = shotDelay;
		}
	}
}
