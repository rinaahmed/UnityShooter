using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	void OnGUI()
	{
		const int buttonWidth = 84;
		const int buttonHeight = 60;

		Rect buttonRect = new Rect (Screen.width / 2 - (buttonWidth / 2)
		                           , (2 * Screen.height / 3)
		                           , buttonWidth
		                           , buttonHeight);

		if (GUI.Button (buttonRect, "Start!")) 
		{
			Application.LoadLevel ("AwesomeLevel");
		}
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	

	}
}
