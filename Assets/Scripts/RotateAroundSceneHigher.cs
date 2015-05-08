using UnityEngine;
using System.Collections;


public class RotateAroundSceneHigher : MonoBehaviour {

	public Transform target;
	public float speed=5.0f;
	public float bounds = 12f;

	void Start () {
	
	}
	
	void Update () {
		if (transform.position.x >= bounds && speed > 0) {
			speed *= -1.0f;
		}
		if (transform.position.x <= -bounds && speed < -0) {
			speed *= -1.0f;
		}
		transform.Translate(Vector3.right * Time.deltaTime * speed);
		transform.LookAt(target);
	}
}
