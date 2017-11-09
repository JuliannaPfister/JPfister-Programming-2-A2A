using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {
	// the player speed
	public float topSpeed;
	//tells the direction the player is facing
	bool facingRight = true;
	//get animator
	Animator anim;
	//not grounded
	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	//the jump force
	public float jumpForce = 700f;
	// what layer is considered ground
	public LayerMask whatIsGround;
	private Rigidbody2D rb;



	void Start()
	{
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D> ();


	}





	void FixedUpdate ()
	{


		rb.AddForce(Vector2.up*-200f);
		// if the ground transform hit the whatisground with groundradius
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

		//tells the animator that player is grounded
		anim.SetBool("Ground", grounded);


		//move direction
		float move = Input.GetAxis("Horizontal");

		//adds velocity to the rigidbody in the move direction * speed
		GetComponent<Rigidbody2D>().velocity = new Vector2(move*topSpeed, GetComponent<Rigidbody2D>().velocity.y);
		// gets how fast we move up or down from the rigidbody
		anim.SetFloat ("Speed", Mathf.Abs (move));

		// if player is moving left calls the function Flip() if it moves right call function Flip() again
		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();

	}

	void Update()
	{
		if (grounded && Input.GetKeyDown(KeyCode.Space))
		{
			anim.SetBool("Ground", false);
			//add jump force
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
		}
	}

	//the function Flip transforms the scale to flip the player object left or right
	void Flip ()
	{
		facingRight = !facingRight;
		//get local scale
		Vector3 theScale = transform.localScale;
		//flips on x axis
		theScale.x *= -1;
		//appy to local scale
		transform.localScale = theScale;
	}

}
