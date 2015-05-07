using UnityEngine;
using System.Collections;

public class SceneState : MonoBehaviour {

	public static bool retardMode=false;
	public static bool fixConnect=false;

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
				retardMode = true;
				Debug.Log("Retard mode: " + retardMode);
				break;
			case KeyCode.N:
				retardMode = false;
				Debug.Log("Retard mode: " + retardMode);
				break;
			case KeyCode.F:
				fixConnect=true;
				Debug.Log("Fixed connect: " + fixConnect);
				break;
			case KeyCode.B:
				fixConnect=false;
				Debug.Log("Fixed connect: " + fixConnect);
				break;
			}

		}
	}
}
