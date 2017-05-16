using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GameObject currentCheckpoint;
	private PlayerBehaviour player;

	public GameObject deathParticle;
	public GameObject spawnParticle;

	public int deathPointPenalty;

	public float respawnDelay;

	private float gravityStore;

	public PlayerHealthManager healthManager;

	private CameraController cameraController;

	private TimeManager time;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerBehaviour>();
		cameraController = FindObjectOfType<CameraController>();
		healthManager = FindObjectOfType<PlayerHealthManager>();
		time = FindObjectOfType<TimeManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RespawnPlayer() {
		// Start Coroutine that handles the player's respawn
		StartCoroutine("RespawnPlayerCo");
	}

	public IEnumerator RespawnPlayerCo() {

		// Create instance of DeathParticle
		Instantiate(deathParticle, player.transform.position, player.transform.rotation);

		// Disable the Player and hide them on death
		player.enabled = false;
		player.GetComponent<Renderer>().enabled = false;
		cameraController.isFollowing = false;
		gravityStore = player.GetComponent<Rigidbody2D>().gravityScale;
		player.GetComponent<Rigidbody2D>().gravityScale = 0f;
		player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

		ScoreManager.AddPoints(-deathPointPenalty);

		// printf to make sure it works
		Debug.Log("Player Respawn");

		// Wait for respawnDelay seconds before continuing
		yield return new WaitForSeconds(respawnDelay);

		// Move Player to the position of currentCheckpoint
		player.transform.position = currentCheckpoint.transform.position;

		player.knockbackCount = 0;
		// Re-enable Player and make them visible again
		player.enabled = true;
		player.GetComponent<Rigidbody2D>().gravityScale = gravityStore; 
		player.GetComponent<Renderer>().enabled = true;
		healthManager.PlayerFullHealth();
		healthManager.isDead = false;
		cameraController.isFollowing = true;
		time.ResetTime();

		// Create instance of SpawnParticle at currentCheckpoint
		Instantiate(spawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
	}
}
