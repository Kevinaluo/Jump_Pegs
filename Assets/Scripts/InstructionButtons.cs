using UnityEngine;
using System.Collections;

public class InstructionButtons : MonoBehaviour 
{
	void OnGUI () 
	{
		GUIStyle style = new GUIStyle("button");
		style.fontSize = 50;
		if(GUI.Button(new Rect(Screen.width * (float)0.05, Screen.height * (float)0.1,
		                       Screen.width * (float) 0.2, Screen.height * (float) 0.15), "Main Menu", style)) 
		{
			Application.LoadLevel("Main Menu");
		} 
		if(GUI.Button(new Rect(Screen.width * (float)0.75, Screen.height * (float)0.1,
		                       Screen.width * (float) 0.2, Screen.height * (float) 0.15), "Play", style)) 
		{
			Application.LoadLevel("Just One Left");
		}
	}
}
