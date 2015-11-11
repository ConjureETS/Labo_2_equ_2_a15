using UnityEngine;
using System.Collections;

public class FireScript : MonoBehaviour {

    public Rigidbody2D rocket;
    public Vector3 rocket_position_offset;
    public float speed = 10f;

    // Update is called once per frame
    void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            FireRocket(gameObject.GetComponent<PlayerBehavior>().GetFacingRight());
        }
            
    }

    void FireRocket(bool facingRight)
    {
        //Instantiate new rocket
        Rigidbody2D rocketClone = (Rigidbody2D)Instantiate(rocket, transform.position, Quaternion.identity);
       
        //Sets rocket to be the player's
        rocketClone.gameObject.GetComponent<RocketBehaviour>().SetProperty(true);

        if (!facingRight)
        {
            //Flip the rocket
            Vector3 scale = rocketClone.gameObject.transform.localScale;
            scale.x *= -1;
            rocketClone.gameObject.transform.localScale = scale;

            //Substract the offset
            rocketClone.gameObject.transform.position -= rocket_position_offset;
        }
        else
        {
            //Add the offset
            rocketClone.gameObject.transform.position += rocket_position_offset;
        }
        //Make the rocket move
        rocketClone.velocity = new Vector2(speed * transform.localScale.x, 0);
    }
}
