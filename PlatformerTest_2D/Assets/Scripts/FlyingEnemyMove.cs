using UnityEngine;
using System.Collections;

public class FlyingEnemyMove : MonoBehaviour {

	private PlayerBehaviour player;
	public float moveSpeed;
	public float seekRange;
	public LayerMask playerLayer;
	public bool isPlayerInRange;
	public bool isPlayerFacingAway;
	public bool isFollowOnLookAway;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerBehaviour>();
	}
	
	// Update is called once per frame
	void Update () {
		isPlayerInRange = Physics2D.OverlapCircle(transform.position, seekRange, playerLayer);

		if (!isFollowOnLookAway) {
			if (isPlayerInRange) {
				transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
				return;
			}
		}

		if ((player.transform.position.x < transform.position.x && player.transform.localScale.x < 0) ||
			(player.transform.position.x > transform.position.x && player.transform.localScale.x > 0)) {
			isPlayerFacingAway = true;
		} else {
			isPlayerFacingAway = false;
		}

		if (isPlayerInRange && isPlayerFacingAway) {
			transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
		}
	}

	void OnDrawGizmosSelected() {
		Gizmos.DrawSphere(transform.position, seekRange);
	}
}
