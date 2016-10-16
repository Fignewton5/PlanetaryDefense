using UnityEngine;
using System.Collections;

public class FireProjectile : MonoBehaviour {

	public Vector3 centerOfScreen;			//vector for center of screen
	public Vector3 projectileTrajectory;	//vector for trajectory of projectile 
	private Vector2 forceVector;			//vector2d version of trajectory for rigidbody.addforce

	public float forceModifier;				//modifier that affects how fast the projectiles move towards the planet


	// Use this for initialization
	void Start () {

		//set vector to center of screen's position
		centerOfScreen = 
			Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, Camera.main.transform.position.z));

		//get vector for line from spawner to center of screen
		projectileTrajectory = centerOfScreen - transform.position;

		forceVector = new Vector2(projectileTrajectory.x, projectileTrajectory.y);
	
	}
	
	// Update is called once per frame
	void Update () {

		GetComponent<Rigidbody2D>().AddForce(forceVector * forceModifier);

	}
}
