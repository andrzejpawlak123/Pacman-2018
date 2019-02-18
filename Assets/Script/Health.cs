using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public static Health Instance { set; get; }
    public Text MyText;
    int points = IAPMenager.hp +1;
    // Update is called once per frame
    void Update()
    {
       
        MyText.text = "hp: "+ points.ToString();
    }
}

