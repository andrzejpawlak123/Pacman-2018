using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PacDots : MonoBehaviour
{
    public static int winGamePac;
    public GameObject prefab;
    public GameObject map;
    public GameObject[] tablicaPrefab;
    void Start()
    {
        prefab = GameObject.Find("food");
        map = GameObject.Find("map");
        winGamePac = 0;
        for (int i = 0; i < 29; i++) //29
        {
            for (int j = 0; j < 26; j++)//26
            {
                Instantiate(prefab, new Vector3(j + 2.0F, i + 2.0F, 0), Quaternion.identity);
                winGamePac++;
            }
        }
        FoodLogic.winGameHere = winGamePac;
    }
}
