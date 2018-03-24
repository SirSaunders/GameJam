﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleDoor : MonoBehaviour {

	private int state = 0;
	public float openCount = 0;
	private Vector3[] closed = new Vector3[2];
	private Vector3[] open = new Vector3[2];
	// Use this for initialization
	void Start () {
		closed [0] = new Vector3 (transform.position.x + .825f, 0f, transform.position.z + 0f);
			closed[1]  = new Vector3 (transform.position.x + -.825f, 0f,transform.position.z +  0f) ;
		open [0] = new Vector3 (transform.position.x + 2.475f, 0f, transform.position.z + .1f);
		open[1] = new Vector3 (transform.position.x + -2.475f, 0f,transform.position.z +  .1f) ;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (state);
		switch (state){
		case 0:
			Vector3 pos = this.transform.position;
			float position = Mathf.Sqrt ((pos.x * pos.x) + (pos.z * pos.z));
			GameObject[] people = GameObject.FindGameObjectsWithTag ("Person");
			for (int i = 0; i < people.Length; i++) {
				Vector3 person = people [i].transform.position;
				float per = Mathf.Sqrt ((person.x * person.x) + (person.z * person.z));
				if (Mathf.Abs (position - per) < 5) {
					state = (state + 1) % 4;
					break;
				}
			}
			break;
		case 1:
			Transform[] transforms = this.GetComponentsInChildren<Transform> ();
			if (transforms [1].position.x >= open [0].x || transforms [2].position.x <= open [1].x) {
				state = (state + 1) % 4;
				openCount = 5.0f * Time.deltaTime;
			} else {
				transforms [1].position = new Vector3 (transforms [1].position.x + (1.65f / Time.deltaTime), transforms [1].position.y, transforms [1].position.z + (.1f / Time.deltaTime));
				transforms [2].position = new Vector3 (transforms [2].position.x + (-1.65f / Time.deltaTime), transforms [2].position.y, transforms [2].position.z + (.1f / Time.deltaTime)); 
			}
			break;
		case 2:
			if (openCount > 0) {
				openCount--;
			} else {
				state = (state + 1) % 4;
			}
			break;
		case 3:
			Transform[] transforms2 = this.GetComponentsInChildren<Transform> ();
			if (transforms2 [1].position.x <= closed [0].x || transforms2 [2].position.x >= closed [1].x ){
				state = (state + 1) % 4;
				openCount = 5 * Time.deltaTime;
			} else {
				transforms2 [1].position = new Vector3 (transforms2 [1].position.x - (1.65f / Time.deltaTime), transforms2 [1].position.y, transforms2 [1].position.z - (.1f / Time.deltaTime));
				transforms2 [2].position = new Vector3 (transforms2 [2].position.x - (-1.65f / Time.deltaTime), transforms2 [2].position.y, transforms2 [2].position.z - (.1f / Time.deltaTime)); 
			}
			break;
	}
}
}
