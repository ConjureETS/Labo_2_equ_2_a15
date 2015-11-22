using UnityEngine;
using System.Collections;

public class RocketBehaviour : MonoBehaviour {

    private bool isAPlayerRocket;

	public GameObject explosion;

	void FixedUpdate ()
	{
		Destroy(gameObject, 2);
	}

    //Destroys the rocket when no longer visible
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    //Destroys the rocket when it hits something (except Player when its his rocket)
	void OnCollisionEnter2D(Collision2D collision)
    {
		//if collision.gameObject,tag == "enemy"
		// If it hits an enemy...
		if (collision.gameObject.tag == "Enemy") {
			// ... find the Enemy script and call the Hurt function.
			collision.gameObject.GetComponent<Health> ().removeHP(1);

			// call the explosion animation
			Explode ();
			
			// Destroy the rocket.
			Destroy (gameObject);
		} else if (!isAPlayerRocket || collision.gameObject.tag != "Player") {
			// call the explosion animation
			Explode ();
			Destroy (gameObject);
		}
    }

	public void Explode()
	{
		// Create a quaternion with a random rotation in the z-axis.
		Quaternion randomRotation = Quaternion.Euler (0f, 0f, Random.Range (0f, 360f));
		
		// Instantiate the explosion where the rocket is with the random rotation.
		Instantiate (explosion, transform.position, randomRotation);
	}

    public void SetProperty(bool playerRocket)
    {
        isAPlayerRocket = playerRocket;
    }
}
