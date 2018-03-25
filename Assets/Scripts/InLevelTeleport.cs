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
			Debug.Log (PlayerTracker.PlayerPostion.x);
			Debug.Log (PlayerTracker.PlayerPostion.z);

				if (Mathf.Abs (tele1.transform.position.x -PlayerTracker.PlayerPostion.x) < 1 && Mathf.Abs (tele1.transform.position.z -PlayerTracker.PlayerPostion.z) < 1) {
					telportPlayer(1);
					openCount = Time.fixedTime;
				}else if (Mathf.Abs (tele2.transform.position.x - PlayerTracker.PlayerPostion.x) < 1 && Mathf.Abs (tele2.transform.position.z - PlayerTracker.PlayerPostion.z) < 1) {
					telportPlayer(2);
					openCount = Time.fixedTime;
				}else if (Mathf.Abs (tele3.transform.position.x - PlayerTracker.PlayerPostion.x) < 1 && Mathf.Abs (tele3.transform.position.z - PlayerTracker.PlayerPostion.z) < 1) {
					telportPlayer(3);
					openCount = Time.fixedTime;
				}else if (Mathf.Abs (tele4.transform.position.x - PlayerTracker.PlayerPostion.x) < 1 && Mathf.Abs (tele4.transform.position.z - PlayerTracker.PlayerPostion.z) < 1) {
					telportPlayer(4);
					openCount = Time.fixedTime;
				}	
			}

	}


	void telportPlayer(int telNum){
		Debug.Log ("tel to: " + telNum);
		int telTo = Random.Range (0, 3);
			if(telTo+1 == telNum){
			telportPlayer (telNum); 
			}
		switch (telTo){
		case 0:
			transportPlayer(tele1.transform.position);		
			break;
		case 1:
			transportPlayer(tele2.transform.position);		
			break;
		case 2:
			transportPlayer(tele3.transform.position);		
			break;
		case 3:
			transportPlayer(tele4.transform.position);		
			break;
		}
	}

	void transportPlayer(Vector3 position){
		GameObject player = GameObject.Find ("/Player");
		Debug.Log ("tel to: " + position);
		player.transform.position = new Vector3(position.x,1,position.z);		

	}
}

