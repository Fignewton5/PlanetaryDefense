using UnityEngine;
using System.Collections;

public class SpawnProjectile : MonoBehaviour {

	public GameObject projectilePrefab;		//prefab for projectile
	public Vector3 centerOfScreen;			//vector for center of screen in world points
	public bool isFiring;					//flag to check if firing projectile
	private GameObject projectileInstance;	//GO of spawned projectile

	// Use this for initialization
	void Start () {

		isFiring = false;
	}

	void Update(){

		/*if(Input.GetButtonDown("Jump")){


			fireProjectile();
		}*/

	}

	public void fireProjectile(){

		//GO to represent projectile
		projectileInstance =
			Instantiate(projectilePrefab, transform.position, transform.rotation) as GameObject;
		
		//set spawned projectile to location of spawner
		projectileInstance.transform.position = transform.position;
		


	}
}
