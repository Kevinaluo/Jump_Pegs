using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinMessage : MonoBehaviour {
	Text text;

	// Use this for initialization
	void Awake () 
	{
		text = GetComponent <Text> ();
		text.text = "";
	}
	
	// Update is called once per frame
	void Update () 
	{
 		if(GameLogic.restart)
		{
			Awake();
		} 
		else if (GameLogic.pegsLeft == 1)
		{
			text.text = "Congratulations";
		}
	}
}
