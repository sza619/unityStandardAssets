using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AvoidMemoryLeak : MonoBehaviour {
	private bool started = false;
	private float timeLeft = 5;
	
	public void Update() {
		ParticleSystem system = GetComponent<ParticleSystem>();
		if (system.isPlaying && started == false) {
			started = true;
		}
		timeLeft -= Time.deltaTime;
		if (timeLeft <= 0 && started == true) {
			GameObject.Destroy(gameObject);
		}
	}
}