using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class HealthPickup : MonoBehaviour
{

	public Text health;

	void OnTriggerEnter2D(Collider2D other)
	{			
		if(other.tag == "Player")
		{
			// Destroy the crate.
			Destroy(gameObject);

			//heal player
			health.text = "Health: " + gameObject.GetComponent<Health>().addHP(3);

		}
			
	}
}
