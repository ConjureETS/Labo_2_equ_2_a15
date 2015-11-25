using UnityEngine;
using System.Collections;

public class BombPickup : MonoBehaviour
{


	void Awake()
	{

	}


	void OnTriggerEnter2D (Collider2D other)
	{
		// If the player enters the trigger zone...
		if(other.tag == "Player")
		{
			// Increase the number of bombs the player has.
			other.GetComponent<LayBombs>().bombCount++;

			// Destroy the crate.
			Destroy(gameObject);
		}

	}
}
