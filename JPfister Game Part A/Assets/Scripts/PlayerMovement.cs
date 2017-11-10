using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    //MOVEMENT 

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

    //COMBAT

    //player health
    public int health = 6;
    // invincible time after player gets hurt
    public float blinkTime = 2f;



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

    void Hurt()
    {
        // if health is lower than zero, restart game
        health--;
        if (health <= 0)
            Application.LoadLevel(Application.loadedLevel);
        //if health isnt lower than zero, triggers the blink time
        else
            TriggerHurt(blinkTime);
    }

    public void TriggerHurt(float hurtTime)
    {
        StartCoroutine(HurtBlinker(hurtTime));
    }

    IEnumerator HurtBlinker(float hurtTime)
    {
        //ignore collision with enemies
        int enemyLayer = LayerMask.NameToLayer("Enemy");
        int playerLayer = LayerMask.NameToLayer("Player");
        

        Physics2D.IgnoreLayerCollision(enemyLayer,playerLayer);
        //start looping blinking anim
        anim.SetLayerWeight(1, 1);

        //wait for invincibility to end
        yield return new WaitForSeconds(hurtTime);
        //stops blinking animation and re enable collision
        Physics2D.IgnoreLayerCollision(enemyLayer, playerLayer,false);
        anim.SetLayerWeight(1, 0);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if player collides with enemy, calls function Hurt()
        Enemy enemy = collision.collider.GetComponent<Enemy>();
        if (enemy != null)
        {
            Hurt();
        }
    }
    
        
   
}
