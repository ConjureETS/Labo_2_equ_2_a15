using UnityEngine;
using System.Collections;

public class CollisionCheck : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "Enemy")
        {
            Debug.Log(gameObject.GetComponent<Health>().removeHP(1));
        }
    }
}
