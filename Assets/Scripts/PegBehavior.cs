using UnityEngine;
using System.Collections;

public class PegBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (name == "Peg 1") 
		{
			renderer.enabled = false;
		} 
		else
		{
			renderer.enabled = true;
		}
		renderer.material.color = Color.gray;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameLogic.changePegState)
		{
			if(GameLogic.restart == true)
			{
				Start ();
			}
			checkShouldChangeSelectedPegColor ();
			checkShouldChangeAllColorGray ();
			checkShouldMakeJumpMove (); 
		}
	}
	
	void checkShouldChangeSelectedPegColor () 
	{
		if (GameLogic.selectedPegName == name )
		{
			renderer.material.color = Color.blue;
		}
		else
		{
			renderer.material.color = Color.gray;
		}
	}
	
	void checkShouldChangeAllColorGray() 
	{
		if (GameLogic.selectedPegName == ""  &&
		    GameLogic.locationName == "" &&
		    GameLogic.middlePegName == "")
		{
			renderer.material.color = Color.gray;
		}
	}

	void checkShouldMakeJumpMove() 
	{
		if (GameLogic.selectedPegName != ""  &&
		    GameLogic.locationName != "" &&
		    GameLogic.middlePegName != "")
		{
			if (name == GameLogic.selectedPegName)
			{
				renderer.enabled = false;
			} 
			else if (name == GameLogic.locationName)
			{
				renderer.enabled = true;
			}
			else if (name == GameLogic.middlePegName)
			{
				renderer.enabled = false;
			}
			renderer.material.color = Color.gray;
		}
	}
}
