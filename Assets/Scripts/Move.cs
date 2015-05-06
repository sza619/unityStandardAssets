using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	private float xStartLimit = 0;
	private float xStopLimit = 0;
	public float jumpHeight = 2.5f;
	public float movementSpeed = 1.5f;

	public static float platFormWidth = 3.7f;
	public float funnelOneStart 	  = -6-platFormWidth/2;
	public float funnelOneStop 		  = -6+platFormWidth/2;
	public float funnelTwoStart 	  = -2-platFormWidth/2;
	public float funnelTwoStop 		  = -2+platFormWidth/2;
	public float funnelThreeStart 	  =  2-platFormWidth/2;
	public float funnelThreeStop 	  =  2+platFormWidth/2;
	public float funnelFourStart 	  =  6-platFormWidth/2;
	public float funnelFourStop 	  =  6+platFormWidth/2;

	void Start () {
		print (GetComponent<Rigidbody> ().position);
		GetComponent<Rigidbody> ().position = new Vector3 (funnelOneStart+1, 0, 0);	
		GetComponent<Rigidbody> ().velocity = new Vector3(movementSpeed, 0, 0);	
	}

	void FixedUpdate () {
		xStartLimit = funnelOneStart;
		xStopLimit = funnelOneStop;
		Rigidbody rigidBody = GetComponent<Rigidbody>();
		float xPos = rigidBody.position.x;
		if (Input.GetKeyDown(KeyCode.W)) {
			rigidBody.angularVelocity = Vector3.zero;
			rigidBody.velocity = new Vector3(movementSpeed, 0, 0);
			rigidBody.AddForce(Vector3.up*jumpHeight, ForceMode.VelocityChange);
		}
		if (xPos <= this.funnelOneStop && xPos >= this.funnelOneStart) {
			rigidBody.velocity = new Vector3(movementSpeed, rigidBody.velocity.y, 0);
		}
		if (xPos >= this.funnelOneStop || xPos <= this.funnelOneStart) {
			movementSpeed = movementSpeed*-1;
			rigidBody.velocity = new Vector3(movementSpeed, rigidBody.velocity.y, 0);
			transform.Rotate(new Vector3(0, 180, 0));
		}
	}
}
