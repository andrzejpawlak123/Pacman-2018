using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodLogic : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D co)
    {
        if ("player".Equals(co.name)) {
            Destroy(gameObject);
        }
    }
}
