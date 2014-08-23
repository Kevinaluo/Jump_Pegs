using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {
	static int[,,] gameBoardRepresentation;

	public static string selectedPegName;  //The peg that the player first clicks.
	public static string locationName;     //The empty location the selected peg jumps to.
	public static string middlePegName;    //The peg that is being jumped over.

	public static bool changePegState;     //Will communicate with PegBehavior in order to determine
										   //when it is appropriate to change color and disable renderer
	public static bool restart;
	public static int pegsLeft;
	void Start() 
	{
		pegsLeft = 14;
		returnToDefault ();
		gameBoardRepresentation = new int[5, 5, 2];    //1 means rendered. 0 means not rendered.
		int pegNumber = 1;
		for (int i = 0; i < 5; i++) 
		{
			for (int j = 0; j < 5-i; j++) 
			{
				gameBoardRepresentation [i, j, 0] = pegNumber;
				pegNumber++;

				gameBoardRepresentation [i, j, 1] = 1;
			}
		} 
		gameBoardRepresentation [0, 0, 1] = 0;

		for (int i = 0; i < 5; i++) 
		{
			for (int j = 4; j > 5-i; j--) 
			{
				gameBoardRepresentation [i, j, 0] = -1;
				gameBoardRepresentation [i, j, 1] = -1;
			}
		} 
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (restart == true)
		{
			Start ();
		}
		changePegState = false;
		if (selectedPegName == "") 
		{
			string nameOfObjectClicked = getNameOfObjectClicked ();
			if (checkPegRendered(nameOfObjectClicked))
			{
				restart = false;
				selectedPegName = nameOfObjectClicked;
				changePegState = true;
			}
		}
		else if (selectedPegName != "" && locationName == "")
		{
			string nameOfLocationClicked = getNameOfObjectClicked ();
			if (checkPegRendered(nameOfLocationClicked))
			{
				selectedPegName = nameOfLocationClicked;
				changePegState = true;
			} 
			else if (!checkPegRendered(nameOfLocationClicked))
			{
				locationName = nameOfLocationClicked;
				changePegState = true;
			}
		}
		else if (selectedPegName != "" && locationName != "" && middlePegName == "")
		{
			if(checkIfMoveIsValid()) 
			{
				changePegState = true;
			}
			else if (!checkIfMoveIsValid())
			{
				returnToDefault ();
			}
		}
		else if (selectedPegName != "" && locationName != "" && middlePegName != "") 
		{
			returnToDefault();
			pegsLeft--;
		}
	}


	string getNameOfObjectClicked ()
	{
		string name = "";
		if(Input.GetButtonUp ("Fire1"))
		{
			Ray ray = getRay ();
			RaycastHit hit;
			bool isColliderHit = Physics.Raycast (ray, out hit);
			if (isColliderHit)
			{
				name = hit.transform.name;
			}
			else if(!isColliderHit)
			{
				returnToDefault ();
			}
		}
		return name;
	}

	bool checkPegRendered (string name)
	{
		bool output = false;;
		for (int i = 0; i < 5; i++) 
		{
			for (int j = 0; j < 5-i; j++) 
			{
				if ("Peg " + gameBoardRepresentation [i, j, 0] == name)
				{
					output = gameBoardRepresentation [i, j, 1] == 1;
				}
			}
		} 
		return output;
	}

	bool checkIfMoveIsValid ()
	{
		bool output = false;
		
		int[] selectedPegCoordinates = getIandJCoordinates (selectedPegName);  // I and J values for the selected peg.
		int[] locationPegCoordinates = getIandJCoordinates (locationName);     // I and J values for the location peg.
		
		int pegIValueDifference = locationPegCoordinates[0] - selectedPegCoordinates[0];
		int pegJValueDifference = locationPegCoordinates[1] - selectedPegCoordinates[1];
		int[] middlePegCoordinates = new int[2];
		middlePegCoordinates[0] = selectedPegCoordinates[0] + pegIValueDifference/2;
		middlePegCoordinates[1] = selectedPegCoordinates[1] + pegJValueDifference/2;
		middlePegName = "Peg " + gameBoardRepresentation[middlePegCoordinates[0], 
		                                                 middlePegCoordinates[1], 0];
		if ((pegIValueDifference == -2 && pegJValueDifference == 0) |
		    (pegIValueDifference == 2 && pegJValueDifference == -2) |
		    (pegIValueDifference == 0 && pegJValueDifference == 2)  |
		    (pegIValueDifference == 2 && pegJValueDifference == 0)  |
		    (pegIValueDifference == -2 && pegJValueDifference == 2) |
		    (pegIValueDifference == 0 && pegJValueDifference == -2) &&
		    checkPegRendered(middlePegName))
		{
			output = true;
			changeGameBoardRepresentationRenderedState(selectedPegCoordinates, 
			                                           locationPegCoordinates,
			                                           middlePegCoordinates);

		}
		return output;
	}

	Ray getRay () 
	{
		Ray ray = new Ray (Vector3.zero, Vector3.zero);
		if (Input.GetMouseButtonUp (0)) 
		{
			ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		} else {
			ray = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);
		}
		return ray;
	}

	int [] getIandJCoordinates (string name)
	{
		int[] coordinates = new int[2];
		for (int i = 0; i < 5; i++) 
		{
			for (int j = 0; j < 5 - i; j++) 
			{
				if("Peg " + gameBoardRepresentation [i, j, 0] == name)
				{
					coordinates[0] = i;
					coordinates[1] = j;
				}
			}
		}
		return coordinates;
	}

	void changeGameBoardRepresentationRenderedState(int[] selectedPegCoordinates, 
	                                                int[] locationPegCoordinates,
													int[] middlePegCoordinates)
	{
		gameBoardRepresentation [selectedPegCoordinates [0], selectedPegCoordinates [1], 1] = 0;
		gameBoardRepresentation [locationPegCoordinates [0], locationPegCoordinates [1], 1] = 1;
		gameBoardRepresentation [middlePegCoordinates [0], middlePegCoordinates [1], 1] = 0;
	}

	void returnToDefault () 
	{
		selectedPegName = "";
		locationName = "";
		middlePegName = "";
		changePegState = true;
	}
}
