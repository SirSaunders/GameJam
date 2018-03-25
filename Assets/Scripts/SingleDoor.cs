using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DoubleDoor : MonoBehaviour {

	private int state = 0;
	public float openCount = 0;
	private float previousTime = 0;
	private Vector3 open1;
	private Vector3 open2;
	private Vector3 door1;
	private Vector3 door2;

	// Use this for initialization
	void Start () {
		door1 = transform.Cast<Transform>().ToList() [0].position;
		door2 = transform.Cast<Transform>().ToList() [1].position;

		open1 = new Vector3 (door1.x + 2.475f, 0f, door1.z + .1f);
		open2 = new Vector3 (door2.x - 2.475f, 0f, door1.z + .1f);
	}
	
	// Update is called once per frame
	void Update () {

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
			transforms [1].position = open2;//open2;
	//			Debug.Log(transforms [1].position);
		//	}
			break;
		case 2:
			Debug.Log (open1.x + ","+open1.y+","+open1.z);
			Debug.Log (transform.Cast<Transform>().ToList()[0].position.x+","+transform.Cast<Transform>().ToList()[0].position.y+","+transform.Cast<Transform>().ToList()[0].position.z);
			Debug.Log (door1.x+","+door1.y+","+door1.z);
			if(Time.fixedTime - openCount  > 5){
				state = (state + 1) % 4;
				previousTime = Time.fixedTime;
			}
			break;
		case 3:
			List<Transform> transforms2 = transform.Cast<Transform>().ToList();
			if (Time.fixedTime - previousTime  > 2 && ( transforms2 [0].position.x <= door1.x || transforms2 [1].position.x >= door2.x) ){
				state = (state + 1) % 4;
			} else {
				transforms2 [0].position = door1;
				transforms2 [1].position = door2; 
			}
			break;
	}
}
}
