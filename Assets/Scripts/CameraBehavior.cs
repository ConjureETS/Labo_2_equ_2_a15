using UnityEngine;
using System.Collections;

public class CameraBehavior : MonoBehaviour {

    public GameObject player;
    private float zAxis;

	// Use this for initialization
	void Start () {
        zAxis = gameObject.transform.position.z;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        gameObject.transform.position = new Vector3(player.transform.position.x, 0, zAxis);
	}
}
