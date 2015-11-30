using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FallCheck : MonoBehaviour {

    public GameObject player;
    public GameObject cam;
    public Text health;
	
	// Update is called once per frame
	void FixedUpdate () {

        if (player.transform.position.y < cam.transform.position.y - cam.transform.localScale.y)
        {
            player.transform.position = new Vector3(0, 0, 0);
            health.text = "Health: " + player.GetComponent<Health>().removeHP(1);
            if (player.GetComponent<Health>().getHP() == 0)
            {
                player.GetComponent<PlayerBehavior>().Death();
            }
        }
	}
}
