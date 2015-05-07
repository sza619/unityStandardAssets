using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	private float xStartLimit = 0;
	private float xStopLimit = 0;
	public int currentStep = 0;
	public float jumpHeight = 2.5f;
	public float movementSpeed = 1.5f;
	public bool jumping = false;

	public bool aboutToJump;
	public bool aboutToDie;

	public float stepOffset    = 1.85f; //half the width of a platform
	public int[] stepPos       = {-6, -2, 2, 6}; //center of the platforms

	void Start () {
		xStartLimit = stepPos[currentStep]-stepOffset;
		xStopLimit = stepPos[currentStep]+stepOffset;
		Rigidbody rigidbody = GetComponent<Rigidbody> ();
		rigidbody.position = new Vector3 (xStartLimit+1, 0, Random.Range(-0.5f, 0f));
		rigidbody.velocity = new Vector3(movementSpeed, 0, 0);	
	}

	void FixedUpdate () {
		Rigidbody lemming = GetComponent<Rigidbody>();
		listenForJump();
		listenForDeath();
		if (notNearLedge(lemming)) {
			lemming.velocity = new Vector3(movementSpeed, lemming.velocity.y, 0);
		}
		if (atLedge(lemming)) {
			if(aboutToJump && atRightLedge(lemming)) {
				jump(lemming);
			} else if(aboutToDie && atRightLedge(lemming)) {
				die(lemming);
			} else {
				turnAround(lemming);
			}
		}
	}

	void OnCollisionEnter(Collision col) {
		if(col.gameObject.name == "Door" || col.gameObject.name == "Dirt bottom") {
			print (col.gameObject.name);
			Destroy(gameObject);
		}
	}

	void jump(Rigidbody rigidbody) {
		rigidbody.angularVelocity = Vector3.zero;
		rigidbody.velocity = new Vector3(movementSpeed, 0, 0);
		rigidbody.AddForce(Vector3.up*jumpHeight, ForceMode.VelocityChange);
		aboutToJump = false;
		currentStep++;
		StartCoroutine(updateLimits());
	}

	void die(Rigidbody rigidbody) {
		rigidbody.velocity = new Vector3(movementSpeed/4, rigidbody.velocity.y, 0);
		updateLimits();
	}

	void turnAround(Rigidbody rigidbody) {
		movementSpeed = movementSpeed*-1;
		rigidbody.velocity = new Vector3(movementSpeed, rigidbody.velocity.y, 0);
		transform.Rotate(new Vector3(0, 180, 0));
	}

	IEnumerator updateLimits() {
		xStopLimit = stepPos[currentStep]+stepOffset;
		yield return new WaitForSeconds(1);
		xStartLimit = stepPos[currentStep]-stepOffset;
	}

	void listenForJump() {
		if (Input.GetKeyDown(KeyCode.J)) {
			aboutToDie = false;
			aboutToJump = true;
		}
	}

	void listenForDeath() {
		if (Input.GetKeyDown(KeyCode.D)) {
			aboutToJump = false;
			aboutToDie = true;
		}
	}

	bool atLedge(Rigidbody rigidbody) {
		float xPos = rigidbody.position.x;
		return xPos >= xStopLimit || xPos <= xStartLimit;
	}

	bool atRightLedge(Rigidbody rigidbody) {
		float xPos = rigidbody.position.x;
		return xPos >= xStopLimit && xPos < stepPos[stepPos.Length-1];
	}

	bool notNearLedge(Rigidbody rigidbody) {
		float xPos = rigidbody.position.x;
		return xPos <= xStopLimit && xPos >= xStartLimit;
	}
}
