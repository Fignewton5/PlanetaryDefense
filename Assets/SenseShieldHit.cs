using UnityEngine;
using System.Collections;

public class SenseShieldHit : MonoBehaviour {

	public GameMasterControl gameMasterScript;	//script to change score and health values
	
	void Start(){
		
		//grab script
		gameMasterScript = GameObject.Find("GameMasterControl").GetComponent<GameMasterControl>();
	}
	
	void OnTriggerEnter2D(Collider2D other){
		
		if(other.gameObject.tag == "HostileProjectile"){

			//destroy the object
			Destroy(other.gameObject);
			
			//reduce planet health and update text
			gameMasterScript.score += 100;
			gameMasterScript.setScoreAndPlanetHP(gameMasterScript.score, gameMasterScript.planetHealth);
			
			Debug.Log("hit by hostile projectile");
		}
		
		
	}
	
}
