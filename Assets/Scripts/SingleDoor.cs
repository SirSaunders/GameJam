using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleDoor : MonoBehaviour {

	private int state = 0;
	public float openCount = 0;
	private float previousTime = 0;
	private Vector3 open1;
	private Vector3 open2;
	private Vector3 door1;
	private Vector3 door2;

	// Use this for initialization
	void Start () {
		door1 = GetComponentsInChildren<Transform> () [1].position;
		door2 = GetComponentsInChildren<Transform> () [2].position;

		open1 = new Vector3 (door1.x + 2.475f, 0f, door1.z + .1f);
		open2 = new Vector3 (door2.x - 2.475f, 0f, door1.z + .1f);
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
				if (Mathf.Abs (pos.x - person.x) < 5 && Mathf.Abs (pos.y - person.y) < 5) {
					state = (state + 1) % 4;
					break;
				}
			}
			break;
		case 1:
			Transform[] transforms = this.GetComponentsInChildren<Transform> ();
			if (transforms [1].position.x >= open1.x || transforms [2].position.x <= open1.x) {
				state = (state + 1) % 4;
				openCount = Time.fixedTime;
			} else {
				transforms [1].position = open1;
				transforms [2].position = open2;
			}
			break;
		case 2:
			Debug.Log (Time.fixedTime );
			Debug.Log (openCount );
			Debug.Log (Time.fixedTime - openCount);
			if(Time.fixedTime - openCount  > 5){
				state = (state + 1) % 4;
				previousTime = Time.fixedTime;
			}
			break;
		case 3:
			Transform[] transforms2 = this.GetComponentsInChildren<Transform> ();
			if (Time.fixedTime - previousTime  > 2 && ( transforms2 [1].position.x <= door1.x || transforms2 [2].position.x >= door2.x) ){
				state = (state + 1) % 4;
			} else {
				transforms2 [1].position = door1;
				transforms2 [2].position = door2; 
			}
			break;
	}
}
}
