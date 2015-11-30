using UnityEngine;
using System.Collections;

public class BombPickup : MonoBehaviour
{
    public AudioClip audioPickup;

	void OnTriggerEnter2D (Collider2D other)
	{
		// If the player enters the trigger zone...
		if(other.tag == "Player")
		{
            AudioSource.PlayClipAtPoint(audioPickup, transform.position);

            // Increase the number of bombs the player has.
            other.GetComponent<LayBombs>().bombCount++;

			// Destroy the crate.
			Destroy(gameObject);
		}

	}
}
