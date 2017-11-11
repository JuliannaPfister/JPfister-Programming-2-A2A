using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrapsScript : MonoBehaviour {

    private PlayerMovement player;

    // Use this for initialization
    void Start() {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
     if(other.CompareTag("player"))
        {
            GetComponent<PlayerMovement>().Hurt();
            
        }
    }


}