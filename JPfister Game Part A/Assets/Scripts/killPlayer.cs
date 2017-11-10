using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class killPlayer : MonoBehaviour
{
	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Player") {
			Destroy (col.gameObject);
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}
	}
}
