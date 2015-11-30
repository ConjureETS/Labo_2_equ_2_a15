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

			// Destroy the crate.
			Destroy(gameObject);

			//heal player
			health.text = "Health: " + gameObject.GetComponent<Health>().addHP(3);

		}
			
	}
}
