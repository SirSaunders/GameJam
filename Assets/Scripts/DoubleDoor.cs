using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SingleDoor : MonoBehaviour {

	private int state = 0;
	public float openCount = 0;
	private float previousTime = 0;
	private Vector3 open1;
	private Vector3 door1;

	// Use this for initialization
	void Start () {
		door1 = transform.Cast<Transform>().ToList() [0].position;

		open1 = new Vector3 (door1.x + 2.475f, 0f, door1.z + .1f);
	}

	// Update is called once per frame
	void Update () {
		Debug.Log (state);

		switch (state){
		case 0:
			Vector3 pos = this.transform.position;
			GameObject[] people = GameObject.FindGameObjectsWithTag ("Person");
			for (int i = 0; i < people.Length; i++) {
				Vector3 person = people [i].transform.position;
				if (Mathf.Abs (pos.x - person.x) < 5 && Mathf.Abs (pos.z - person.z) < 5) {
					state = (state + 1) % 4;
					break;
				}
			}
			break;
		case 1:
			List<Transform> transforms = transform.Cast<Transform>().ToList();
			//if (transforms [0].position.x >= open1.x || transforms [1].position.x <= open1.x) {
			state = (state + 1) % 4;
			openCount = Time.fixedTime;
			//	} else {
			transforms [0].position = open1;
			//			Debug.Log(transforms [1].position);
			//	}
			break;
		case 2:
			if(Time.fixedTime - openCount  > 5){
				state = (state + 1) % 4;
				previousTime = Time.fixedTime;
			}
			break;
		case 3:
			List<Transform> transforms2 = transform.Cast<Transform>().ToList();
			if (Time.fixedTime - previousTime  > 2 && ( transforms2 [0].position.x <= door1.x) ){
				state = (state + 1) % 4;
			} else {
				transforms2 [0].position = door1;
			}
			break;
		}
	}
}
