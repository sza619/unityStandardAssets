using UnityEngine;
using System.Collections;

public class CameraAngles : MonoBehaviour {

	public Camera mainCam;
	public Camera walkAwayCam;
	public Camera walkTowardsCam;
	public Camera walkAwayAngleCam;
	public Camera walkTowardsAngleCam;
	public Camera topDown;
	public Camera walkWithCam;

	void Start () {
		StartCoroutine(gogoCameras ());
	}

	IEnumerator gogoCameras() {
		switchToCam (walkWithCam);
		yield return new WaitForSeconds(50f);

		switchToCam (mainCam);
		yield return new WaitForSeconds(5f);

		switchToCam (walkAwayCam);
		yield return new WaitForSeconds(0.5f);

		switchToCam (walkTowardsCam);
		yield return new WaitForSeconds(0.5f);

		switchToCam (walkAwayAngleCam);
		yield return new WaitForSeconds(0.5f);

		switchToCam (walkTowardsAngleCam);
		yield return new WaitForSeconds(0.5f);

		switchToCam (topDown);
		yield return new WaitForSeconds(2.5f);

		switchToCam (mainCam);
	}

	void switchToCam(Camera camera) {
		mainCam.enabled = false;
		walkAwayCam.enabled = false;
		walkTowardsCam.enabled = false;
		walkAwayAngleCam.enabled = false;
		walkTowardsAngleCam.enabled = false;
		topDown.enabled = false;
		camera.enabled = true;
	}

}
