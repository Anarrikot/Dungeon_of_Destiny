using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapone : MonoBehaviour
{

    public string name;
    public int damage;
    public float recharge;
    public int PurchasePrice;
    public int NextUpgradeCost;
    public GameObject button;
    public Sprite one, two;


    public bool CheckUpgradeCost(int money)
    {
        if(money < NextUpgradeCost)
        {
            return false;
        }
        return true;
    }
    public void Start()
    {

    }
}
