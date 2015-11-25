using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CollisionCheck : MonoBehaviour {

    public Text health;


    public void initText(int hp)
    {
        health.text = "Health: " + hp;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "Enemy")
        {
            health.text = "Health: " + gameObject.GetComponent<Health>().removeHP(1);
        }

        if(gameObject.GetComponent<Health>().getHP() == 0)
        {
            gameObject.GetComponent<PlayerBehavior>().Death();
        }
    }


}
