using UnityEngine;
using System.Collections;

public class MainMenuButtons : MonoBehaviour
{

	void OnGUI ()
	{
		GUIStyle style = new GUIStyle("button");
		style.fontSize = 55;
		if(GUI.Button(new Rect(Screen.width * (float)0.4, Screen.height * (float) 0.43,
		                       Screen.width * (float) 0.2, Screen.height * (float) 0.15), "Play", style)) 
		{
			Application.LoadLevel("Just One Left");
		} 
		if(GUI.Button(new Rect(Screen.width * (float)0.4, Screen.height * (float) 0.65,
		                       Screen.width * (float) 0.2, Screen.height * (float) 0.15), "Instructions", style)) 
		{
			Application.LoadLevel("Instructions");
		}
	}
}
