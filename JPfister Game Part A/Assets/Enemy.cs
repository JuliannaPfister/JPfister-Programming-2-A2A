using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    // the enemy speed
    public float velocity = 1f;
    //rigidbody
    private Rigidbody2D rb;
    public Transform sightStart;
    public Transform sightEnd;
    public bool colliding;
    public LayerMask detectWhat;

    // Use this for initialization
    void Start () {
        // get the component rigidbody2d
        rb = GetComponent<Rigidbody2D>();
      
		
	}
	
	// Update is called once per frame
	void Update () {

        

        rb.velocity = new Vector2(velocity, rb.velocity.y);
        colliding = Physics2D.Linecast(sightStart.position, sightEnd.position, detectWhat);

        if (colliding)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            velocity *= -1;
        }
	}
}
