using UnityEngine;
using System.Collections;

public class FallCheck : MonoBehaviour {

    public GameObject player;
    public GameObject cam;
	
	// Update is called once per frame
	void FixedUpdate () {

        if (player.transform.position.y < cam.transform.position.y - cam.transform.localScale.y)
            player.transform.position = new Vector3(0, 0, 0);
	}
}
