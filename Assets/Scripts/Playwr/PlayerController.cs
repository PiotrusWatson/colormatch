using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	Rigidbody2D rb2D;
	float horizontal;
	float vertical;

	bool isMoving; //This bool will be used for animating the walk cycle :)

	public int speed = 10;
	// Use this for initialization
	void Awake () 
	{
		rb2D = GetComponent<Rigidbody2D> (); //boilerplate setting up

	}
	
	// Update is called once per frame
	void Update () {
		horizontal = Input.GetAxis ("Horizontal"); //storing variables so i can do checks against them :)
		vertical =  Input.GetAxis ("Vertical"); 

		if (horizontal != 0) //This code ensures the player doesnt move diagonally
			vertical = 0;

		rb2D.velocity = new Vector2 (horizontal, vertical) * speed; //moves the player 
	}
}
