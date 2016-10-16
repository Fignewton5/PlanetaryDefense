using UnityEngine;
using System.Collections;

public class YouLosePopup : MonoBehaviour {

	public float horizPadding;			//padding around buttons in popup box
	public float vertPadding;

	private float buttonWidth;			//self-explanatory
	public float buttonHeight;

	void Start(){

		//calculate button width so that it is centered properly
		buttonWidth = (Screen.width/2) - 2*horizPadding;
	}

	void OnGUI(){

		GUI.Box (new Rect(Screen.width/4, Screen.height/4, Screen.width/2, Screen.height/2), "\n\nThe Planet Has Been Obliterated!");

		//play again button
		if(GUI.Button(new Rect(Screen.width/4 + horizPadding, Screen.height/4 + vertPadding*2, buttonWidth, buttonHeight), "Play Again")){

			//reload level
			Application.LoadLevel(3);
		}


		//return to main menu button
		if(GUI.Button(new Rect(Screen.width/4 + horizPadding, Screen.height/4 + vertPadding*3.50f, buttonWidth, buttonHeight), "Main Menu")){
			
			//load main menu
			Application.LoadLevel(0);
		}
	}
}
