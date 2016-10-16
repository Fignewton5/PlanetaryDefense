using UnityEngine;
using System.Collections;

public class Instructions : MonoBehaviour {

	//variables to allow changing of desired
	//screen resolution in editor
	public int width;
	public int height;
	
	//padding for GUI buttons in boxes
	public float horizPadding;
	public float vertPadding;

	// Use this for initialization
	void Start () {
		
		//set screen resolution
		Screen.SetResolution(width, height, false);
	}


	void OnGUI(){

		//box to hold all other buttons / options / description
		GUI.Box (new Rect(width/4, height/4, width/2, height/2), "\n\nHow to Play:\n\n Press 'A' and 'D' to move your shield around the planet.\n\n " +
			"Intercept incoming projectiles with your shield\n in order to stop the planet from being destroyed. \n\n" +
			"The game will end once the planet is destroyed (reaches 0%).");
		

		
		//Main Menu button
		if(GUI.Button(new Rect(width/4 + horizPadding, height/4 + height/8 + 3*vertPadding, width/4, height/16), "Main Menu")){
			
			//go back to main menu
			Application.LoadLevel(0);
		}
	}
}
