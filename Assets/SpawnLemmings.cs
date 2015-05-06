using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnLemmings : MonoBehaviour {

	public Transform spawnLemmings;
	List<Transform> lemmingList = new List<Transform>();

	void Start () {

	}

	int frame=0;
	void Update () {
		frame++;

		if (frame % 15 != 0) {
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

	void MakeALemmingJump() {
		var ind = randomLemmingIndex ();
		lemmingList [ind].GetComponent<Move> ().aboutToJump = true;
	}

	void MakeALemmingDie() {
		var ind = randomLemmingIndex ();
		lemmingList [ind].GetComponent<Move> ().aboutToDie = true;
	}

	void MakeALemmingSpawn() {
		Transform lemming = Instantiate (spawnLemmings) as Transform;
		lemmingList.Add(lemming);
	}

	int randomLemmingIndex() {
		return Random.Range(0, lemmingList.Count);
	}

}
