using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdagaController : MonoBehaviour {

    // the weapons; speed
    public float speed;
    //the adaga rigidbody
    private Rigidbody2D rb;
    //will acess player movement script
    public PlayerMovement player;
    public Enemy enemy;

    // Use this for initialization
    void Start () {
        //getting the component rigidbody
        rb = GetComponent<Rigidbody2D>();
        //acessing player movement script
        player = FindObjectOfType<PlayerMovement>();
        enemy = FindObjectOfType<Enemy>();

        if (player.transform.localScale.x < 0)
            speed = -speed;
		
	}
	
	// Update is called once per frame
	void Update () {
        //adding velocity and speed (movement) to the weapon
        rb.velocity = new Vector2(speed, rb.velocity.y);
        
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy (gameObject);
    }

  

}

