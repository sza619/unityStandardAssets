using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	private float xStartPos = 0;
	private float xStopPos = 0;
	private int currentStep = 0;
	public float jumpHeight = 2.5f;
	public float movementSpeed = 1.5f;
	public bool jumping = false;

	public bool aboutToJump;
	public bool aboutToDie;

	public float stepOffset    = 1.85f;
	public int[] stepPos       = {-6, -2, 2, 6};
	public float stepOnePos    = -6;
	public float stepTwoPos    = -2;
	public float stepThreePos  =  2;
	public float stepFourPos   =  6;

	void Start () {
		xStartPos = stepPos[currentStep]-stepOffset;
		xStopPos = stepPos[currentStep]+stepOffset;
		Rigidbody rigidbody = GetComponent<Rigidbody> ();
		rigidbody.position = new Vector3 (xStartPos+1, 0, 0);	
		rigidbody.velocity = new Vector3(movementSpeed, 0, 0);	
	}

	void FixedUpdate () {
		Rigidbody rigidbody = GetComponent<Rigidbody>();
		float xPos = rigidbody.position.x;
		if (Input.GetKeyDown(KeyCode.Y)) {
			aboutToJump = true;
		}
		if (xPos <= xStopPos && xPos >= xStartPos) {
			rigidbody.velocity = new Vector3(movementSpeed, rigidbody.velocity.y, 0);
		}
		if (xPos >= xStopPos || xPos <= xStartPos) {
			if(aboutToJump && xPos >= xStopPos && xPos < stepFourPos) {
				jump(rigidbody);
			} else {
				turnAround(rigidbody);
			}
		}
	}

	void jump(Rigidbody rigidbody) {
		rigidbody.angularVelocity = Vector3.zero;
		rigidbody.velocity = new Vector3(movementSpeed, 0, 0);
		rigidbody.AddForce(Vector3.up*jumpHeight, ForceMode.VelocityChange);
		aboutToJump = false;
		currentStep++;
		StartCoroutine(updatePositions());
	}

	void turnAround(Rigidbody rigidbody) {
		movementSpeed = movementSpeed*-1;
		rigidbody.velocity = new Vector3(movementSpeed, rigidbody.velocity.y, 0);
		transform.Rotate(new Vector3(0, 180, 0));
	}

	IEnumerator updatePositions() {
		xStopPos = stepPos[currentStep]+stepOffset;
		yield return new WaitForSeconds(1);
		xStartPos = stepPos[currentStep]-stepOffset;
	}
}
