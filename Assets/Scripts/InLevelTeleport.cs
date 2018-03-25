using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InLevelTeleport : MonoBehaviour {

	private float openCount;

	// Use this for initialization
	void Start () {
		openCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.fixedTime - openCount > 10) {
			if (Mathf.Abs (GameObject.FindGameObjectWithTag("Tele1").transform.position.x - transform.position.x) < .5 && Mathf.Abs (GameObject.FindGameObjectWithTag("Tele1").transform.position.z) < .5) {
				transform.position = GameObject.FindGameObjectWithTag("Tele2").transform.position;
				transform.rotation = GameObject.FindGameObjectWithTag("Tele2").transform.rotation;
				openCount = Time.fixedTime;
			}else if (Mathf.Abs (GameObject.FindGameObjectWithTag("Tele2").transform.position.x - transform.position.x) < .5 && Mathf.Abs (GameObject.FindGameObjectWithTag("Tele2").transform.position.z) < .5) {
				transform.position = GameObject.FindGameObjectWithTag("Tele3").transform.position;
				transform.rotation = GameObject.FindGameObjectWithTag("Tele3").transform.rotation;
				openCount = Time.fixedTime;
			}else if (Mathf.Abs (GameObject.FindGameObjectWithTag("Tele3").transform.position.x - transform.position.x) < .5 && Mathf.Abs (GameObject.FindGameObjectWithTag("Tele3").transform.position.z) < .5) {
				transform.position = GameObject.FindGameObjectWithTag("Tele4").transform.position;
				transform.rotation = GameObject.FindGameObjectWithTag("Tele4").transform.rotation;
				openCount = Time.fixedTime;
			}else if (Mathf.Abs (GameObject.FindGameObjectWithTag("Tele4").transform.position.x - transform.position.x) < .5 && Mathf.Abs (GameObject.FindGameObjectWithTag("Tele4").transform.position.z) < .5) {
				transform.position = GameObject.FindGameObjectWithTag("Tele1").transform.position;
				transform.rotation = GameObject.FindGameObjectWithTag("Tele1").transform.rotation;
				openCount = Time.fixedTime;
			}	
		}
	}
}
