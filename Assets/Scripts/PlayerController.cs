using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
		var z = Input.GetAxis("Vertical") ;
		var x = Input.GetAxis("Horizontal") ;

		if(GvrControllerInput.IsTouching){
			z = GvrControllerInput.TouchPosCentered[1];
			x = GvrControllerInput.TouchPosCentered[0];
		}
		z= z  * Time.deltaTime * 3.0f;
		x= x  * Time.deltaTime * 3.0f;
		//transform.Rotate (0, Camera.main.transform.eulerAngles.y, 0);
		float yRotation = Camera.main.transform.eulerAngles.y;
		transform.eulerAngles = new Vector3( transform.eulerAngles.x, yRotation, transform.eulerAngles.z );
		transform.Translate(x, 0, z);
		Vector3 PlayerPOS = GameObject.Find ("/Player").transform.position;
		GameObject.Find ("/Camera").transform.position = new Vector3 (PlayerPOS.x, PlayerPOS.y, PlayerPOS.z);


	}
}
