using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		try {  
				int DistanceAway = 0;
				Vector3 PlayerPOS = GameObject.Find ("/Player").transform.position;
				transform.position = new Vector3 (PlayerPOS.x, PlayerPOS.y, PlayerPOS.z - DistanceAway);
			} catch {
	
			}
	}
}
