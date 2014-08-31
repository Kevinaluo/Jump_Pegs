using UnityEngine;
using System.Collections;

public class Game_Buttons : MonoBehaviour 
{
	void OnGUI ()
	{
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		GUIStyle style = new GUIStyle("button");
		style.fontSize = 50;
		if(GUI.Button(new Rect(Screen.width * (float)0.05, Screen.height * (float)0.1,
		                       Screen.width * (float) 0.2, Screen.height * (float) 0.15), "Restart", style)) 
		{
			GameLogic.setRestart (true);
			GameLogic.setPegsLeft(14);
		} 
		if(GUI.Button(new Rect(Screen.width * (float)0.75, Screen.height * (float)0.1,
		                       Screen.width * (float) 0.2, Screen.height * (float) 0.15), "Main Menu", style)) 
		{
			Application.LoadLevel("Main Menu");
		}
	}
}
