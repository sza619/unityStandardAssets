using UnityEngine;
using System.Collections;


public class RotateAroundScene : MonoBehaviour {

	public Transform target;
	public float speed=5.0f;

	void Start () {
	
	}
	
	void Update () {
		if (transform.position.x > 12.0f) {
			speed *= -1.0f;
		}
		if (transform.position.x < -12.0f) {
			speed *= -1.0f;
		}
		transform.Translate(Vector3.right * Time.deltaTime * speed);
		transform.LookAt(target);
	}
}
