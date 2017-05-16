using UnityEngine;
using System.Collections;

public class DestroyFinishedParticle : MonoBehaviour {

	private ParticleSystem thisParticleSystem;

	// Use this for initialization
	void Start () {
		// Get the ParticleSystem attached to the current gameObject
		thisParticleSystem = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		// If Particle is still running, ignore
		if (thisParticleSystem.isPlaying) {
			return;
		}

		// Destroy particle once animation completed (frees up space)
		Destroy(gameObject);
	}

	// Destroys particle effect once it is no longer on the screen 
	void OnBecameInvisible() {
		Destroy(gameObject);
	}
}
