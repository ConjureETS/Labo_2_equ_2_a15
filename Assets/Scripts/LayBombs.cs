using UnityEngine;
using System.Collections;

public class LayBombs : MonoBehaviour
{
	[HideInInspector]
	public bool bombLaid = false;		// si une bombe a été lancé
	[HideInInspector]
	public int bombCount = 0;			// nombre bomb que le joueur possede

	public GameObject bomb;				// Prefab of the bomb.


	private GUITexture bombHUD;			// affiche si le joueur possede une bombe


	void Awake ()
	{
		// Setting up the reference.
		bombHUD = GameObject.Find("ui_bombHUD").GetComponent<GUITexture>();
	}


	void Update ()
	{
		// si le bouton est pressé et qu'aucune bombe n'a été lancé et qu'on a des bombes
		if(Input.GetButtonDown("Fire2") && !bombLaid && bombCount > 0)
		{
			// Decremente le nb de bombe
			bombCount--;

			// lance une bombe
			bombLaid = true;

			// Instancie la bombe
			Instantiate(bomb, transform.position, transform.rotation);
		}

		// active le display de bombe si le joueur possede des bombes(true) sinon false
		bombHUD.enabled = bombCount > 0;
	}
}
