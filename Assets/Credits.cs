using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {
	
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
		GUI.Box (new Rect(width/4, height/4, width/2, height/2), "\n\nCredits:\n\n Programming & Art:\n\n " +
		         "Tony Anziano\n\n\n\n" +
		         "Dedicated to Robert Carl Anziano\n02/03/1943 - 02/14/2014");
		
		
		
		//Main Menu button
		if(GUI.Button(new Rect(width/4 + horizPadding, height/4 + height/8 + 3*vertPadding, width/4, height/16), "Main Menu")){
			
			//go back to main menu
			Application.LoadLevel(0);
		}
	}
}
