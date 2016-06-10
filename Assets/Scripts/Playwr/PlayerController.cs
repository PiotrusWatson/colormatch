using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	/*Todo: make movement not feel terrible - add some resistance to axis maybe?
	 * Rotate player according to axis pressed - basically specific rotation values depending on whether horizontal or vertical > or < 0
	 * Refactor everything and make code use functions nicely 
	 * Do sword
	 * maybe look into fancy animation stuff like blend trees etc - for now can make do with bools and specific rotation code but w/e
	 */

	/*
	PLAN:
	Aight so this code needs to find A: the first axis pressed
	B: rotate based on the value in that axis to a specific degree
	C: move forwards in that axis while taking any other axis presses as a way of moving diagonally
		C1: if other direction is let go, goes back to rotating
    D: turn on animation, and turn it off the second movement stops
	E: 
	*/
	Rigidbody2D rb2D;
	float horizontalRaw; //These store the RAW values taken straight from axes
	float verticalRaw;

	int horizontal;
	int vertical;

	enum Direction{North, East, South, West, Nowhere}

	Animator animator;

	bool isMoving; //This bool will be used for animating the walk cycle :)

	public int speed = 10;
	// Use this for initialization
	void Awake () 
	{
		rb2D = GetComponent<Rigidbody2D> (); //boilerplate setting up
		animator = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		horizontalRaw = Input.GetAxis ("Horizontal"); //storing variables so i can do checks against them :)
		verticalRaw =  Input.GetAxis ("Vertical"); 

		horizontal = Rounder (horizontalRaw);
		vertical = Rounder(verticalRaw); //Here i round them to ints in the vain hope that this will make the movement feel not shit

		Debug.Log (horizontal);

		isMoving = horizontal != 0 || vertical != 0; //if player is moving, it = true, else it = false

		rb2D.velocity = new Vector2 (horizontal, vertical) * speed;
		animator.SetBool ("IsMoving", isMoving);	//Uses the "isMoving" bool to turn on the player's animtion
		/*
		

		if (horizontal == 0)
			realHorizontal = 0;
		if (vertical == 0)
			realVertical = 0;


		 

		; 


		 //moves the player */
	}

	Direction GetDirection(float xAxis, float yAxis)
	/*Takes horizontal and vertical values, returns direction name :)*/
	{
		if (xAxis == 1)
			return Direction.East;
		else if (xAxis == -1)
			return Direction.West;
		else if (yAxis == 1)
			return Direction.North;
		else if (yAxis == -1)
			return Direction.South;
		else
			return Direction.Nowhere;

	}

	void RotatePlayer ()
	{
		//PLACEHOLDER
	}

	int Rounder(float flaot)
	//Rounds up if greater than 0, or down if less than 0 its nice ok
	{
		if (flaot > 0)
			return Mathf.CeilToInt (flaot);
		else if (flaot < 0)
			return Mathf.FloorToInt (flaot);
		else
			return 0;
	}






		
}
