using UnityEngine;
using System.Collections;

public class TitleScreen : MonoBehaviour {

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

		//box to hold all other buttons / options
		GUI.Box (new Rect(width/4, height/4, width/2, height/2), "Welcome to Planetary Defense!");

		//start game button
		if(GUI.Button(new Rect(width/4 + horizPadding, height/4 + vertPadding, width/4, height/8), "Start Game")){

			//go to game scene
			Application.LoadLevel(3);
		}

		//how to play button
		if(GUI.Button(new Rect(width/4 + horizPadding, height/4 + height/8 + 2*vertPadding, width/4, height/16), "How To Play")){

			//go to instructions scene
			Application.LoadLevel(1);
		}

		//credits button
		if(GUI.Button(new Rect(width/4 + horizPadding, height/4 + height/8 + 3*vertPadding, width/4, height/16), "Credits")){

			//go to credits scene
			Application.LoadLevel(2);
		}
	}

}
