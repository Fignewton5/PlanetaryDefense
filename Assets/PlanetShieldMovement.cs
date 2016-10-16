using UnityEngine;
using System.Collections;

public class PlanetShieldMovement : MonoBehaviour {

	public float rotationSpeed;


	// Update is called once per frame
	void Update () {

		//rotate right on "D" press
		if(Input.GetKey("d")){
			transform.RotateAround(transform.position, Vector3.forward, -rotationSpeed * Time.deltaTime);
		}

		//rotate left on "A" press
		else if(Input.GetKey("a")){
			transform.RotateAround(transform.position, Vector3.forward, rotationSpeed * Time.deltaTime);
		}
	
	}
}
