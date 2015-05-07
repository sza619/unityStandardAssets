using UnityEngine;
using System.Collections;

public class CameraAngles : MonoBehaviour {

	public Camera mainCam;
	public Camera walkAwayCam;
	public Camera walkTowardsCam;
	public Camera walkAwayAngleCam;
	public Camera walkTowardsAngleCam;
	public Camera topDown;
	public Camera firstPersonCam;

	void Start () {
		switchToCam (mainCam);
	}

	void OnGUI() {
		Event e = Event.current;
		if (e.isKey) {
			switch(e.keyCode) {
			case KeyCode.Alpha1:
				switchToCam (mainCam);
				break;
			case KeyCode.Alpha2:
				switchToCam (walkAwayCam);
				break;
			case KeyCode.Alpha3:
				switchToCam (walkTowardsCam);
				break;
			case KeyCode.Alpha4:
				switchToCam (walkAwayAngleCam);
				break;
			case KeyCode.Alpha5:
				switchToCam (walkTowardsAngleCam);
				break;
			case KeyCode.Alpha6:
				switchToCam (topDown);
				break;
			case KeyCode.Alpha7:
				switchToCam (firstPersonCam);
				break;
			}
		}
		
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
