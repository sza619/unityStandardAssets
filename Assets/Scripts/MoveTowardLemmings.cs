using UnityEngine;
using System.Collections;

public class MoveTowardLemmings : MonoBehaviour {

	public GameObject lemmingGroup;
	public Transform lemmingHair;

	public float smooth = 1.5f;         // The relative speed at which the camera will catch up.
	
	private Vector3 relCameraPos;       // The relative position of the camera from the player.
	private float relCameraPosMag;      // The distance of the camera from the player.
	private Vector3 newPos;             // The position the camera is trying to reach.

	private bool cameraSet=false;

	void Awake ()
	{

	}

	public float interpVelocity;
	public float minDistance;
	public float followDistance;
	public GameObject target;
	public Vector3 offset;
	Vector3 targetPos;

	public bool lookTowardCastle=true;

	void FixedUpdate ()
	{
		Transform [] t = lemmingGroup.GetComponentsInChildren<Transform> ();
		if (t.Length < 9) {
			return;
		} else {
			lemmingHair = t [8];
		}

		transform.position = lemmingHair.position;

		if (lemmingHair.parent.GetComponent<Move> ().movementSpeed < 0 && lookTowardCastle) {
			lookTowardCastle = false;
			transform.Rotate (0, 180, 0);
		}
		else if (lemmingHair.parent.GetComponent<Move> ().movementSpeed > 0 && !lookTowardCastle) {
			lookTowardCastle = true;
			transform.Rotate (0, 180, 0);
		}
	}
}
