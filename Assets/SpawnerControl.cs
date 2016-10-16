using UnityEngine;
using System.Collections;

public class SpawnerControl : MonoBehaviour {

	public float spawnerCircleRadius;					//radius of ring of spawners
	public Vector2 centerOfCircle;						//center of ring of spawners
	public float horizontalSpaceBetweenSpawners;		//space on x-axis between each spawner
	public int numberOfSpawnersDesired;					//number of spawners needed to be made
	public GameObject spawnerPrefab;					//prefab for spawner
	public GameObject[] spawnerList;					//array to hold all of the spawners

	//Equation of Circle
	// (x-h)^2 + (y-k)^2 = r^2

	// Use this for initialization
	void Start () {

		//reference to SpawnerContainer's Transform
		//for linking children later
		Transform containerXForm = this.transform;

		//actual number of spawners
		int numberOfSpawners = 0;

		centerOfCircle.x = transform.position.x;
		centerOfCircle.y = transform.position.y;

		//calculate number of spawners
		numberOfSpawnersDesired = Mathf.FloorToInt(((spawnerCircleRadius * 2) / horizontalSpaceBetweenSpawners) * 2);

		//initialize array of spawners
		spawnerList = new GameObject[numberOfSpawnersDesired];

		//create ring of spawners
		for(float x = 0 - spawnerCircleRadius; numberOfSpawners < numberOfSpawnersDesired; x += horizontalSpaceBetweenSpawners){

			//create two GameObjects, 
			//one for the positive y, and one for negative y
			//(top and bottom halves of circle)
			GameObject tempGO, tempGO2;

			//instantiate game objects
			tempGO = Instantiate(spawnerPrefab, Vector3.zero, transform.rotation) as GameObject;
			tempGO.name = "Spawner" + numberOfSpawners;
			tempGO.transform.parent = this.transform;

			//add to array
			spawnerList.SetValue(tempGO, numberOfSpawners);

			//calculate positive y point
			float yCoord = Mathf.Sqrt(Mathf.Pow(spawnerCircleRadius, 2.0f) - Mathf.Pow(x, 2.0f));

			//set position along circle of new spawner
			tempGO.transform.position = new Vector3(x, yCoord, 0f);


			//condition to stop algorithm from creating
			//two spawners at each edge of circle
			//(left-most and right-most points)
			if(numberOfSpawners != 0 && numberOfSpawners != numberOfSpawnersDesired - 1){

				//increment number of spawners
				numberOfSpawners++;
				
				tempGO2 = Instantiate(spawnerPrefab, Vector3.zero, transform.rotation) as GameObject;
				tempGO2.name = "Spawner" + numberOfSpawners;
				tempGO2.transform.parent = this.transform;

				//add to array
				spawnerList.SetValue(tempGO2, numberOfSpawners);

				//calculate negative y point
				yCoord = yCoord * -1;
				
				//set position along circle of new spawner
				tempGO2.transform.position = new Vector3(x, yCoord, 0f);
			}

			//increment number of spawners
			numberOfSpawners++;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
