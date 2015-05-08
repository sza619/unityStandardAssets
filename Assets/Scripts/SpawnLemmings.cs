using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SpawnLemmings : MonoBehaviour {

	public Transform singupform;
	public Transform singupformDeath;

	public Transform verifyPin;
	public Transform verifyPinDeath;

	public Transform confirmationPage;
	public Transform confirmationPageDeath;

	public Transform redirected;
	public Transform redirectedCastle;

	public Transform spawnLemmings;
	List<Transform> lemmingList = new List<Transform>();

	public static int redirectCount=0;
	public static int[] deathSteps = new int[3];

	public static int lastRedirectFrame=0;

	void Start () {
		MakeALemmingSpawn ();
	}

	public static float stress=0.0f;

	int state_increment=600;

	int frame = 0;
	void Update () {
		frame++;

		if (Input.GetKeyDown (KeyCode.S)) {
			MakeALemmingSpawn();
		}

		float ms = 0.5f + stress;

		if (spawnLemmings.GetComponent<Move> ().movementSpeed < 0) {
			spawnLemmings.GetComponent<Move> ().movementSpeed = (-1.0f)*ms;
		} else {
			spawnLemmings.GetComponent<Move> ().movementSpeed = ms;
		}

		if (SceneState.retardMode) {
			MakeALemmingSpawn ();
			for (int i=0; i<lemmingList.Count; i++) {
				if (lemmingList[i] != null) {
					lemmingList[i].GetComponent<Move>().movementSpeed=2.5f;
				}
			}

			singupform.GetComponent<TextMesh> ().text = "LOL";
			singupformDeath.GetComponent<TextMesh> ().text = "LOL";
			
			verifyPin.GetComponent<TextMesh> ().text = "LOL";
			verifyPinDeath.GetComponent<TextMesh> ().text = "LOL";
			
			confirmationPage.GetComponent<TextMesh> ().text = "LOL";
			confirmationPageDeath.GetComponent<TextMesh> ().text = "LOL";
		}

		if (SceneState.fixConnect) {
			for (int i=0; i<lemmingList.Count; i++) {
				if (lemmingList[i] != null) {
					lemmingList[i].GetComponent<Move>().aboutToJump=true;
				}
			}
		}

		if (frame % 20 == 0) {
			MakeALemmingSpawn ();
		}

		CountAndUpdateLabels ();
		updateText();

		if (frame % 30 != 0) {
			return;
		}
		
		var n = Random.Range(0, 3);
		switch (n) {
		case 0:
			MakeALemmingJump ();
			break;
		case 1:
			MakeALemmingDie ();
			break;
		case 2:
			MakeALemmingSpawn ();
			break;
		}
	}

	void OnGUI() {
		Event e = Event.current;
		if (e.isKey) {
			switch (e.keyCode) {
			case KeyCode.Space:
				MakeALemmingSpawn();
				break;
			}
		}
	}
				
	void MakeALemmingJump() {
		var ind = randomLemmingIndex();
		if (lemmingList [ind] != null) {
			lemmingList [ind].GetComponent<Move> ().aboutToJump = true;
		}
	}

	void MakeALemmingDie() {
		var ind = randomLemmingIndex();
		if (lemmingList [ind] != null) {
			lemmingList [ind].GetComponent<Move> ().aboutToDie = true;
		}
	}
	
	void MakeALemmingSpawn() {
		Transform lemming = Instantiate (spawnLemmings, new Vector3 (Random.Range (-5.0f, -7.4f), 0.733f, Random.Range(-0.5f, 0f)), spawnLemmings.rotation) as Transform;
		lemming.transform.parent = spawnLemmings.parent;
		if (lemming.rotation.y > 0) {
			lemming.Rotate (new Vector3 (0, 180, 0));
			lemming.GetComponent<Move> ().movementSpeed *= -1.0f;
		} 
		lemming.GetComponent<Move> ().movementSpeed *= 3.0f;
		if (Random.value > 0.6) {
			lemming.GetComponent<Move> ().aboutToJump=true;
		}
		lemming.GetComponent<Move> ().movementSpeed = Random.Range (0.75f, 1f)*(lemming.GetComponent<Move> ().movementSpeed/Mathf.Abs(lemming.GetComponent<Move> ().movementSpeed));
		lemmingList.Add(lemming);
	}
	
	int randomLemmingIndex() {
		return Random.Range(0, lemmingList.Count);
	}

	void CountAndUpdateLabels() {
		int singupFormCount = 0;
		int verifyPinCount = 0;
		int confirmationPageCount = 0;
		int redirectedPageCount = 0;

		for (var i=0; i<lemmingList.Count; i++) {
			if (lemmingList[i] != null) {
				switch (lemmingList[i].GetComponent<Move>().currentStep) {
				case 0:
					singupFormCount++;
					break;
				case 1:
					verifyPinCount++;
					break;
				case 2:
					confirmationPageCount++;
					break;
				case 3:
					redirectedPageCount++;
					break;
				}
			}
		}

		singupform.GetComponent<TextMesh> ().text = singupFormCount + " users";
		verifyPin.GetComponent<TextMesh> ().text = verifyPinCount + " users";
		confirmationPage.GetComponent<TextMesh> ().text = confirmationPageCount + " users";
	}

	void updateText() {
		singupformDeath.GetComponent<TextMesh> ().text = "" + deathSteps[0];
		verifyPinDeath.GetComponent<TextMesh> ().text = "" + deathSteps[1];
		confirmationPageDeath.GetComponent<TextMesh> ().text = "" + deathSteps[2];
		redirected.GetComponent<TextMesh> ().text = "" + redirectCount;
		redirectedCastle.GetComponent<TextMesh> ().text = "" + redirectCount;
		redirectedCastle.GetComponent<TextMesh> ().fontSize = Mathf.Max (200, redirectCount-frame/10);
	}
}