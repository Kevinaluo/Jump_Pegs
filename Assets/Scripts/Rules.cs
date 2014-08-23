using UnityEngine;
using System.Collections;

public class Rules : MonoBehaviour {
	public GUIText rules;
	
	void Start () 
	{
		rules.text = 
			"The objective of this game is to eliminate all but one \n " +
			"of the pegs. Eliminate pegs by having them jump over \n " +
			"one another similar to the moveset seen in checker pieces. \n " +
			"First press the desired peg and then the desired empty location. \n " +
			"If the move is valid then the jump will eliminate the \n " +
			"middle peg and move the chosen peg to the previously empty \n" +
			"location. Good luck and have fun!!!!!!!!!!!!!.";
	}
}
