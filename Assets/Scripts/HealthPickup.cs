using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class HealthPickup : MonoBehaviour
{
    public AudioClip audioPickup;
	public Text health;


	void OnTriggerEnter2D(Collider2D other)
	{			
		if(other.tag == "Player")
		{
            AudioSource.PlayClipAtPoint(audioPickup, transform.position);
			health.text = "Health: " + other.gameObject.GetComponent<Health>().addHP(3);


			// Destroy the crate.
			Destroy(gameObject);


		}
			
	}
}
