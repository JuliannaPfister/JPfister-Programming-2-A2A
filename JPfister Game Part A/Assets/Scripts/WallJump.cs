using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : MonoBehaviour {
    public float distance=1f;
    public float speed = 2f;
    PlayerMovement movement;

	// Use this for initialization
	void Start () {

        movement = GetComponent<PlayerMovement>();
		
	}
	
	// Update is called once per frame
	void Update () {

        Physics2D.raycastsStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance);

        if (Input.GetKeyDown(KeyCode.Space) && !movement.groundCheck && hit.collider!=null)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed*hit.normal.x, speed);
        }
		
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * transform.localScale.x * distance);
    }
}
