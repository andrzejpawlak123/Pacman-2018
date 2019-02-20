using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingRestartingGame : MonoBehaviour {
    

	// Use this for initialization
	void Start () {
    }

    public void clickTest()
    {
        Debug.Log("Lest see what happens");
    }

    public void gameOver()
    {
        Application.Quit();
    }

    public void restart()
    {
        SceneManager.LoadScene("walls");
    }

    public void showShop()
    {
        SceneManager.LoadScene("menu");

    }
}
