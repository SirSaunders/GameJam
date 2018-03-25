using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracker : MonoBehaviour {
	public static Vector3 PlayerPostion;
	// Use this for initialization
	void Start () {
		 PlayerPostion = GameObject.Find ("/Player").transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		try {  
				int DistanceAway = 0;
				PlayerPostion = GameObject.Find ("/Player").transform.position;
			transform.position = new Vector3 (PlayerPostion.x, PlayerPostion.y, PlayerPostion.z - DistanceAway);
			} catch {
	
			}
	}
}
