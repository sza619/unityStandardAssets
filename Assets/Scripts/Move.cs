using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	private float limitx = 0;
	private float limity = 0;
	public float jumpHeight = 5f;

	public static float platFormWidth = 3.7f;
	public float funnelOneStart 	= -6-platFormWidth/2;
	public float funnelOneStop 		= -6+platFormWidth/2;
	public float funnelTwoStart 	= -2-platFormWidth/2;
	public float funnelTwoStop 		= -2+platFormWidth/2;
	public float funnelThreeStart 	=  2-platFormWidth/2;
	public float funnelThreeStop 	=  2+platFormWidth/2;
	public float funnelFourStart 	=  6-platFormWidth/2;
	public float funnelFourStop 	=  6+platFormWidth/2;

	
	void Start () {
		print (GetComponent<Rigidbody> ().position);
		//GetComponent<Rigidbody> ().position = new Vector3 (funnelOneStart, 0, -5);	
	}

	void FixedUpdate () {
		if (Input.GetKeyDown(KeyCode.W)) {
			GetComponent<Rigidbody>().velocity = Vector3.zero;
			GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			GetComponent<Rigidbody>().AddForce(Vector3.up*jumpHeight, ForceMode.Impulse);
		}
	}
}
