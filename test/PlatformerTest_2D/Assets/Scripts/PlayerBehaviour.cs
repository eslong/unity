using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

	private Rigidbody2D myRigidbody2D;

	public float jumpHeight;
	public float moveSpeed;
	private float moveVelocity;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool isGrounded;

	private bool isDoubleJumped;

	private Animator anim;

	public Transform firePoint;
	public GameObject ninjaStar;

	public float shotDelay;
	public float shotDelayCounter;

	public float knockback;
	public float knockbackCount;
	public float knockbackLength;
	public bool isKnockbackFromRight;

	public bool isOnLadder;
	public float climbSpeed;
	private float climbVelocity;
	private float gravityStore;

	public AudioSource jumpSoundEffect;

	// Use this for initialization
	void Start () {
		// Set anim to attached Animator
		anim = GetComponent<Animator>();
		myRigidbody2D = GetComponent<Rigidbody2D>();
		gravityStore = myRigidbody2D.gravityScale;
	}

	void FixedUpdate() {
		// Check if the groundCheck point is hitting the ground
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
	}
	
	// Update is called once per frame
	void Update () {

		// Reset double jump check
		if (isGrounded) isDoubleJumped = false;

		anim.SetBool("isGrounded", isGrounded);

		// Jump
		if (Input.GetButtonDown("Jump") && isGrounded) {
			Jump();
		}

		//Double Jump
		if (Input.GetButtonDown("Jump") && !isDoubleJumped && !isGrounded) {
			Jump();
			isDoubleJumped = true;
		}

		moveVelocity = moveSpeed * Input.GetAxisRaw("Horizontal");

		if (knockbackCount <= 0) {
			//Apply lateral movement
			myRigidbody2D.velocity = new Vector2(moveVelocity, myRigidbody2D.velocity.y);
		} else {
			if (isKnockbackFromRight) { // Knocked from right
				myRigidbody2D.velocity = new Vector2(-knockback, knockback);
			} else { 					// Knocked from left
				myRigidbody2D.velocity = new Vector2(knockback, knockback);
			}

			knockbackCount -= Time.deltaTime;
		}

		// Set Speed parameter to x velocity of Player
		anim.SetFloat("Speed", Mathf.Abs(myRigidbody2D.velocity.x));

		// Determine if moving right/left, and flip animation accordingly
		if (myRigidbody2D.velocity.x > 0) {
			transform.localScale = new Vector3(1f, 1f, 1f);
		} else if (myRigidbody2D.velocity.x < 0) {
			transform.localScale = new Vector3(-1f, 1f, 1f);
		}

		if (Input.GetButtonDown("Fire1")) {
			Instantiate(ninjaStar, firePoint.position, firePoint.rotation);
			shotDelayCounter = shotDelay;
		}

		if (Input.GetButton("Fire1")) {
			shotDelayCounter -= Time.deltaTime;

			if (shotDelayCounter <= 0) {
				shotDelayCounter = shotDelay;
				Instantiate(ninjaStar, firePoint.position, firePoint.rotation);
			}
		}

		if (anim.GetBool("isSwordAttack")) anim.SetBool("isSwordAttack", false);

		if (Input.GetButtonDown("Fire2")) {
				anim.SetBool("isSwordAttack", true);
		}

		if (isOnLadder) {
			myRigidbody2D.gravityScale = 0f;
			climbVelocity = climbSpeed * Input.GetAxisRaw("Vertical");
			myRigidbody2D.velocity = new Vector2(myRigidbody2D.velocity.x, climbVelocity);
		}

		if (!isOnLadder) {
			myRigidbody2D.gravityScale = gravityStore;
		}
	
	}

	public void Jump() {
		// Increase player y-axis movement to jumpHeight
		myRigidbody2D.velocity = new Vector2(myRigidbody2D.velocity.x, jumpHeight);
		jumpSoundEffect.Play();
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.transform.tag == "MovingPlatform") {
			transform.parent = other.transform;
		}
	}

	void OnCollisionExit2D(Collision2D other) {
		if (other.transform.tag == "MovingPlatform") {
			transform.parent = null;
		}
	}

}
