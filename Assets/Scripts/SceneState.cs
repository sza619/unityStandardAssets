using UnityEngine;
using System.Collections;

public class SceneState : MonoBehaviour {

	static bool retardMode=false;
	public Transform cameraLemming;

	void Start () {
		
	}
	
	void Update () {
	
	}

	void OnGUI() {
		Event e = Event.current;
		if (e.isKey) {
			switch(e.keyCode) {
			case KeyCode.R:
				retardMode = !retardMode;
				break;
			case KeyCode.Alpha7:
				cameraLemming.position = new Vector3 (-7.4f, 0.733f, -0.5f);
				cameraLemming.rotation = Quaternion.identity;
				break;
			}
		}
	}
}
