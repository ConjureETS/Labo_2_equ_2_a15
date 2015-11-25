using UnityEngine;
using System.Collections;

public class PlayerBehavior : MonoBehaviour
{

    public float maxSpeed = 50.0f;

    // Jump Stuff
    public bool grounded = true;
    public Transform groundCheck;
    private float groundRadius = 0.1f;
    public LayerMask ground;
    public float jumpForce = 7.0f;

    private Rigidbody2D rb;
    private Animator anim;
    private bool facingRight = true;

    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        gameObject.GetComponent<CollisionCheck>().initText(gameObject.GetComponent<Health>().getHP());
    }

    // Update is called once per frame
    void Update()
    {
        if (grounded && Input.GetAxis("Vertical") > 0.0f)
        {
            anim.SetBool("Ground", false);
            rb.AddForce(new Vector2(0, jumpForce));
        }

        //for the shooting animations
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("Shooting", true);

        }
        else
        {
            anim.SetBool("Shooting", false);
        }
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, ground);
        anim.SetBool("Ground", grounded);
        anim.SetFloat("vSpeed", rb.velocity.y);

        float xMove = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xMove * maxSpeed, rb.velocity.y);

        if ((xMove < 0 && facingRight) || (xMove > 0 && !facingRight))
            flip();

        // Change animation according to user inputs
        anim.SetFloat("Speed", Mathf.Abs(xMove));
    }

    public bool GetFacingRight()
    {
        return facingRight;
    }

    private void flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void ResetGame()
    {
        Application.LoadLevel(Application.loadedLevelName);
        Time.timeScale = 1f;
    }
    
    public void Death()
    {
        StartCoroutine(ResetAfterSeconds(5));
        Time.timeScale = 0f;
    }

    private IEnumerator ResetAfterSeconds(int seconds)
    {
        float pauseEndTime = Time.realtimeSinceStartup + seconds;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return null; // Attend un frame
        }

        // Reset and count deaths
        ResetGame();
    }
}
