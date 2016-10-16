using UnityEngine;
using System.Collections;

public class GameMasterControl : MonoBehaviour {

	//variables to allow changing of desired
	//screen resolution in editor
	public int width;
	public int height;

	//variables to keep track of 
	//score and planet health
	public int score;
	public int planetHealth;

	public float timeBetweenProjectiles;		//period of time between firing projectiles
	public float upperBound;					//upper bound for Random function to grab random spawner from array

	public GameObject scoreText;				//actual gameobjects for GUI Text
	public GameObject planetIntText;

	public GameObject spawnerContainer;			//game object that holds all the spawners
	public SpawnerControl spawnerContainerScript;

	public bool startVolley;					//flag to start launching projectiles
	public bool lostGame = false;				//to flag game over
	private bool playingGame = true;

	void Awake () {

		//set screen resolution
		Screen.SetResolution(width, height, false);
	}

	// Use this for initialization
	void Start () {

		//initializing variables
		score = 0;
		planetHealth = 100;
		spawnerContainerScript = spawnerContainer.GetComponent<SpawnerControl>();


	
	}

	public void setScoreAndPlanetHP(int score, int planetHP){

		//alter score text
		scoreText.GetComponent<GUIText>().text = "Score: " + score;

		//alter planet health text
		planetIntText.GetComponent<GUIText>().text = planetHP + "%";
	}

	void Update (){

		//while game is active
		if(startVolley == true && lostGame == false){

			//launch coroutine of firing projectiles
			StartCoroutine(fireFromRandomSpawner());

			//turn flag off
			startVolley = false;

		}

		//if health drops below 1%, you lose
		if(planetHealth < 1 && lostGame == false){

			//destroy any leftover projectiles
			GameObject[] toBeDestroyed = GameObject.FindGameObjectsWithTag("HostileProjectile");
			foreach(GameObject GO in toBeDestroyed){
				Destroy(GO);
			}

			//activate necessary flags
			lostGame = true;
			playingGame = false;

			//stop firing projectiles
			StopCoroutine(fireFromRandomSpawner());

			//create gameobject with guiText
			GameObject loserText = new GameObject("LoserText");

			//position in middle of screen
			loserText.transform.position = new Vector3(0.5f, 0.5f, 0.0f);
			loserText.AddComponent<GUIText>();
			loserText.GetComponent<GUIText>().anchor = TextAnchor.MiddleCenter;

			//change font
			loserText.GetComponent<GUIText>().fontSize = 50;
			loserText.GetComponent<GUIText>().color = Color.red;
			loserText.GetComponent<GUIText>().fontStyle = FontStyle.Bold;
			loserText.GetComponent<GUIText>().text = "YOU HAVE LOST";

			//activate post-game menu
			GameObject loseMenu = GameObject.Find("YouLose!");
			loseMenu.GetComponent<YouLosePopup>().enabled = true;
		}

	}

	/*public void fireFromRandomSpawner(){

		//grab total number of spawners
		upperBound = spawnerContainerScript.numberOfSpawnersDesired - 1;

		//grab a spawner from the list of spawners
		int randomedSpawner = Mathf.FloorToInt(Random.Range(0.0f, upperBound));

		//spawn projectile from random spawner

		//grab script of selected spawner
		SpawnProjectile fireProjectileScript = 
			spawnerContainerScript.spawnerList[randomedSpawner].GetComponent<SpawnProjectile>();

		//fire projectile
		fireProjectileScript.fireProjectile();
	}*/

	IEnumerator fireFromRandomSpawner(){

		//grab total number of spawners
		upperBound = spawnerContainerScript.numberOfSpawnersDesired - 1;
		
		//grab a spawner from the list of spawners
		int randomedSpawner = Mathf.FloorToInt(Random.Range(0.0f, upperBound));
		
		//spawn projectile from random spawner
		
		//grab script of selected spawner
		SpawnProjectile fireProjectileScript = 
			spawnerContainerScript.spawnerList[randomedSpawner].GetComponent<SpawnProjectile>();
		
		//fire projectile
		fireProjectileScript.fireProjectile();

		//wait n seconds according to parameter
		yield return new WaitForSeconds(timeBetweenProjectiles);


		//if game still in play
		//recursively launch a projectile every n seconds
		if(playingGame == true){

			//recursively launch another
			StartCoroutine(fireFromRandomSpawner());
		}

	}
}
