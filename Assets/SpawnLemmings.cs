using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnLemmings : MonoBehaviour {

	public Transform spawnLemmings;
	List<Transform> lemmingList = new List<Transform>();

	void Start () {
		for (var i=0; i<5; i++) {
			Transform lemming = Instantiate (spawnLemmings) as Transform;
			lemming.GetComponent<Move>().movementSpeed+=i;
			lemmingList.Add(lemming);
		}

	}
	
	void Update () {
	}

}
