using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour
{
	public float bombRadius = 0.5f;			// Radius within which enemies are killed.
	public float fuseTime = 1.5f;
	public GameObject explosion;			// Prefab of explosion effect.


	private LayBombs layBombs;				// Reference to the player's LayBombs script.




	void Awake ()
	{
		if(GameObject.FindGameObjectWithTag("Player"))
			layBombs = GameObject.FindGameObjectWithTag("Player").GetComponent<LayBombs>();
	}

	void Start ()
	{
		
		// If the bomb has no parent, it has been laid by the player and should detonate.
		if(transform.root == transform)
			StartCoroutine(BombDetonation());
	}


	IEnumerator BombDetonation()
	{
		// Wait for 2 seconds.
		yield return new WaitForSeconds(fuseTime);

		// Explode the bomb.
		Explode();
	}


	public void Explode()
	{
		
		// The player is now free to lay bombs when he has them.
		layBombs.bombLaid = false;

		// Find all the colliders on the Enemies layer within the bombRadius.
		Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, bombRadius, 1 << LayerMask.NameToLayer("Enemies"));

		// For each collider...
		foreach(Collider2D col in enemies)
		{
			// Check if it has a rigidbody (since there is only one per enemy, on the parent).
			Rigidbody2D rb = col.GetComponent<Rigidbody2D>();
			if(rb != null && rb.tag == "Enemy")
			{
				// Find the Enemy script and set the enemy's health to zero.
				rb.gameObject.GetComponent<Health>().removeHP(1000);
			}
		}

		// Create a quaternion with a random rotation in the z-axis.
		Quaternion randomRotation = Quaternion.Euler (0f, 0f, Random.Range (0f, 360f));
		
		// Instantiate the explosion where the rocket is with the random rotation.
		Instantiate (explosion, transform.position, randomRotation);

		// Destroy the bomb.
		Destroy (gameObject);
	}
}
