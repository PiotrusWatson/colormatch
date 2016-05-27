using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	/*Todo: make movement not feel terrible - add some resistance to axis maybe?
	 * Rotate player according to axis pressed - basically specific rotation values depending on whether horizontal or vertical > or < 0
	 * Refactor everything and make code use functions nicely 
	 * Do sword
	 * maybe look into fancy animation stuff like blend trees etc - for now can make do with bools and specific rotation code but w/e
	 */
	Rigidbody2D rb2D;
	float horizontal;
	float vertical;


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
		horizontal = Input.GetAxis ("Horizontal"); //storing variables so i can do checks against them :)
		vertical =  Input.GetAxis ("Vertical"); 

		if (horizontal != 0) //This code ensures the player doesnt move diagonally
			vertical = 0;

		isMoving = horizontal != 0 || vertical != 0; //if player is moving, it = true, else it = false

		animator.SetBool ("IsMoving", isMoving);


		rb2D.velocity = new Vector2 (horizontal, vertical) * speed; //moves the player 
	}
}
