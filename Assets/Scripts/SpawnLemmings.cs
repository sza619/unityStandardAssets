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
	
	void Start () {
		MakeALemmingSpawn ();
	}
	
	int frame = 0;
	void Update () {
		CountAndUpdateLabels ();
		frame++;

		if (frame > 3000) {
			singupform.GetComponent<TextMesh> ().text = "LOL";
			singupformDeath.GetComponent<TextMesh> ().text = "LOL";
			
			verifyPin.GetComponent<TextMesh> ().text = "LOL";
			verifyPinDeath.GetComponent<TextMesh> ().text = "LOL";
			
			confirmationPage.GetComponent<TextMesh> ().text = "LOL";
			confirmationPageDeath.GetComponent<TextMesh> ().text = "LOL";
			
			redirected.GetComponent<TextMesh> ().text = "LOL";
			redirectedCastle.GetComponent<TextMesh> ().text = "LOL";
		}

		if (frame < 5) {
			MakeALemmingSpawn ();
		}
		
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
		
		if (frame > 1000) {
			for (var i=0; i<lemmingList.Count; i++) {
				if (lemmingList[i] != null) {
					lemmingList[i].GetComponent<Move>().aboutToJump = true;
				}
			}
		}
		
		if (frame > 1500) {
			MakeALemmingSpawn ();
		}
		
		if (frame > 2000) {
			for (var i=0; i<lemmingList.Count; i++) {
				if (lemmingList[i] != null) {
					lemmingList[i].GetComponent<Move>().movementSpeed++;
					singupform.GetComponent<TextMesh>().text="LOL";
					singupform.GetComponent<TextMesh>().text="LOL";
					singupform.GetComponent<TextMesh>().text="LOL";
					singupform.GetComponent<TextMesh>().text="LOL";
					singupform.GetComponent<TextMesh>().text="LOL";
					singupform.GetComponent<TextMesh>().text="LOL";
					singupform.GetComponent<TextMesh>().text="LOL";

				}
			}
		}


	}
	
	void MakeALemmingJump() {
		var ind = randomLemmingIndex();
		if (lemmingList [ind] != null) {
			lemmingList [ind].GetComponent<Move> ().aboutToJump = true;
			lemmingList.RemoveAt (ind);
		}
	}
	
	void MakeALemmingDie() {
		var ind = randomLemmingIndex();
		if (lemmingList [ind] != null) {
			lemmingList [ind].GetComponent<Move> ().aboutToDie = true;
		}
		lemmingList.RemoveAt (ind);
	}
	
	void MakeALemmingSpawn() {
		Transform lemming = Instantiate(spawnLemmings, new Vector3(-7.081089f, 0.0f, 0.0f), Quaternion.identity) as Transform;

		lemmingList.Add(lemming);
	}
	
	int randomLemmingIndex() {
		return Random.Range(0, lemmingList.Count);
	}

	void CountAndUpdateLabels() {
		for (var i=0; i<lemmingList.Count; i++) {
			if (lemmingList[i] != null) {
				switch (lemmingList[i].GetComponent<Move>().currentStep) {
				case 0:
					break;
				}
			}
		}
	}
	
}