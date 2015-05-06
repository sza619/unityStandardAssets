using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	private bool jumping = false;
	private float limitx = 0;
	private float limity = 0;
	public float jumpHeight = 5f;
	
	void Start () {
		//set position to first column
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKeyDown(KeyCode.W)) {
			GetComponent<Rigidbody>().velocity = Vector3.zero;
			GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			GetComponent<Rigidbody>().AddForce(Vector3.up*jumpHeight, ForceMode.Impulse);
		}
	}
}
