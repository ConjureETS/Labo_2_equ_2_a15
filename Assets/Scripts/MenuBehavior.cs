using UnityEngine;
using System.Collections;

public class MenuBehavior : MonoBehaviour {

	public void LoadScene(int level)
    {
        Application.LoadLevel(level);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
