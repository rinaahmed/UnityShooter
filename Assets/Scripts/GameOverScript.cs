using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {

	void OnGUI()
	{
		const int buttonWidth = 120;
		const int buttonHeight = 60;

		const int NUM_BUTTONS = 2;
		string[] buttonDescr = new string[NUM_BUTTONS] {"Retry", "Back to Menu"};
		string[] level = new string[NUM_BUTTONS] { "AwesomeLevel", "MainMenu" };

		for (int i = 0; i < NUM_BUTTONS; ++i) 
		{
			Rect buttonRect = new Rect(Screen.width /2 - (buttonWidth / 2)
			                           , ((i+1)*Screen.height/3) - (buttonHeight / 2)
			                           , buttonWidth
			                           , buttonHeight);

			if (GUI.Button (buttonRect, buttonDescr[i]))
			{
				Application.LoadLevel (level[i]);
			}
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
