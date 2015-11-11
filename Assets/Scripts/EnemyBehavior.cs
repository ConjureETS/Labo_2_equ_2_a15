using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

    private float direction = 1.0f;
    private Rigidbody2D rb;

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
	}
}
