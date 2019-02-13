using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FoodLogic : MonoBehaviour {

    public static int winGameHere;
    
    void OnTriggerEnter2D(Collider2D co)
    {
        if ("player".Equals(co.name)) {
            Destroy(gameObject);
            winGameHere--;
            if (winGameHere == -73 )  //-73
            {
                SceneManager.LoadScene("WinGAme");
            }

        }
        if ("map".Equals(co.name))
        {
            Destroy(gameObject);
            winGameHere--;
        }
    }
}
