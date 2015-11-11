using UnityEngine;
using System.Collections;

public class RocketBehaviour : MonoBehaviour {

    private bool isAPlayerRocket;

    //Destroys the rocket when no longer visible
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    //Destroys the rocket when it hits something (except Player when its his rocket)
	void OnCollisionEnter2D(Collision2D collision)
    {
        if(!isAPlayerRocket || collision.gameObject.tag != "Player")
            Destroy(gameObject);
    }

    public void SetProperty(bool playerRocket)
    {
        isAPlayerRocket = playerRocket;
    }
}
