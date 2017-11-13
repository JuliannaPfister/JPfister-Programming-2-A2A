using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    //enemy health
    public int currentHealth;
    // the enemy speed
    public float velocity = 1f;
    //rigidbody
    private Rigidbody2D rb;
    //the enemy sight start point
    public Transform sightStart;
    //the enemy sight end point
    public Transform sightEnd;
    //determines with enemy collided with walls/tiles 
    public bool colliding;
    // layer mask to define what the enemy will perceve as a colision
    public LayerMask detectWhat;
    //get animator
    Animator anim;

    // Use this for initialization
    void Start()
    {
        // get the component rigidbody2d
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {


        //direction the enemy moves to
        rb.velocity = new Vector2(velocity, rb.velocity.y);
        //cast a horrizontal line to detect colision
        colliding = Physics2D.Linecast(sightStart.position, sightEnd.position, detectWhat);
        //if the enemy detects a colision, transform the local scale and change moving direction
        if (colliding)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            velocity *= -1;
        }


        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }

    }

   



    public void OnTriggerEnter2D(Collider2D other)
    {
        //if enemy collides with weapon 
        if (other.tag == "Weapon")
        {   
            //loses -1 health
            currentHealth--;
            //blinks when takes damage
            anim.SetLayerWeight(1, 1);
        }

        //need to make it stop blinking after 2 secs

        
    }

    

}
