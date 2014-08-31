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
		if (GameLogic.getChangePegState())
		{
			if(GameLogic.getRestart() == true)
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
		if (GameLogic.getPegName("selectedPegName") == name )
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
		if (GameLogic.getPegName("selectedPegName") == ""  &&
		    GameLogic.getPegName("locationName") == "" &&
		    GameLogic.getPegName("middlePegName") == "")
		{
			renderer.material.color = Color.gray;
		}
	}

	void checkShouldMakeJumpMove() 
	{
		if (GameLogic.getPegName("selectedPegName") != ""  &&
		    GameLogic.getPegName("locationName") != "" &&
		    GameLogic.getPegName("middlePegName") != "")
		{
			if (name == GameLogic.getPegName("selectedPegName"))
			{
				renderer.enabled = false;
			} 
			else if (name == GameLogic.getPegName("locationName"))
			{
				renderer.enabled = true;
			}
			else if (name == GameLogic.getPegName("middlePegName"))
			{
				renderer.enabled = false;
			}
			renderer.material.color = Color.gray;
		}
	}
}
