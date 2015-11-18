using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

    private float direction = 1.0f;
    private Rigidbody2D rb;
	private bool facingRight = true;
	private bool dead = false;

	public int HP = 2;


    // Ground
    public GameObject ground;
    private Bounds groundBounds;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();

        groundBounds = ground.GetComponent<Renderer>().bounds;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if ((direction > 0 && transform.position.x >= groundBounds.max.x) ||
            (direction < 0 && transform.position.x <= groundBounds.min.x))
            direction *= -1.0f;

        rb.velocity = Vector2.right * direction;

		if ((direction < 0 && facingRight) || (direction > 0 && !facingRight))
			flip();

		// If the enemy has zero or fewer hit points and isn't dead yet...
		if(HP <= 0 && !dead)
			// ... call the death function.
			Death ();
		
	}
	
	private void flip()
	{
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

	public void Hurt()
	{
		// Reduce the number of hit points by one.
		HP--;
	}

	void Death()
	{	
		// Set dead to true.
		dead = true;
		// delete the enemy
		Destroy(gameObject);
	}


}
