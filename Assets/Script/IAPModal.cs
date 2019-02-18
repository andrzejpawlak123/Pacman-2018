using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAPModal : IAPMenager {


    public void Buy_1()
    {
        IAPMenager.Instance.Buy_Product_food();
    }
    public void Buy_2()
    {
        IAPMenager.Instance.Buy_Product_life();
    }
    public void Buy_NO_Ads()
    {
        IAPMenager.Instance.Buy_Product_noads();
    }
}
