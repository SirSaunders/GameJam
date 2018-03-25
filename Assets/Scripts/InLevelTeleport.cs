using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InLevelTeleport : MonoBehaviour {

	private float openCount;
	private GameObject tele1;
	private GameObject tele2;
	private GameObject tele3;
	private GameObject tele4;





	void Start () {
		openCount = 0;
		tele1 = GameObject.FindGameObjectWithTag ("Tele1");
		tele2 = GameObject.FindGameObjectWithTag ("Tele2");
		tele3 = GameObject.FindGameObjectWithTag ("Tele3");
		tele4 = GameObject.FindGameObjectWithTag ("Tele4");
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.fixedTime - openCount > 10) {
			if (Mathf.Abs (tele1.transform.position.x - transform.position.x) < 1 && Mathf.Abs (tele1.transform.position.z - transform.position.z) < 1) {
				this.transform.position = tele2.transform.position;
				this.transform.rotation = tele2.transform.rotation;
				openCount = Time.fixedTime;
			}else if (Mathf.Abs (tele2.transform.position.x - this.transform.position.x) < 1 && Mathf.Abs (tele1.transform.position.z - this.transform.position.z) < 1) {
				this.transform.position = tele3.transform.position;
				this.transform.rotation = tele3.transform.rotation;
				openCount = Time.fixedTime;
			}else if (Mathf.Abs (tele3.transform.position.x - this.transform.position.x) < 1 && Mathf.Abs (tele3.transform.position.z - this.transform.position.z) < 1) {
				this.transform.position = tele4.transform.position;
				this.transform.rotation = tele4.transform.rotation;
				openCount = Time.fixedTime;
			}else if (Mathf.Abs (tele4.transform.position.x - this.transform.position.x) < 1 && Mathf.Abs (tele4.transform.position.z - this.transform.position.z) < 1) {
				this.transform.position = tele1.transform.position;
				this.transform.rotation = tele1.transform.rotation;
				openCount = Time.fixedTime;
			}	
		}
	}
}

