using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var z = Input.GetAxis("Vertical") ;
		var x = Input.GetAxis("Horizontal") ;

		if(GvrControllerInput.IsTouching){
			z = GvrControllerInput.TouchPosCentered[1];
			x = GvrControllerInput.TouchPosCentered[0];
		}
		z= z  * Time.deltaTime * 3.0f;
		x= x  * Time.deltaTime * 3.0f;
		float yRotation = Camera.main.transform.eulerAngles.y;
		transform.eulerAngles = new Vector3( transform.eulerAngles.x, yRotation, transform.eulerAngles.z );
		transform.Translate(x, 0, z);
		//Camera.main.transform.position = transform.position;


	}
}
