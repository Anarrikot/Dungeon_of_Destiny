using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    public static int lives = 100;
    public static float speed = 10;
    public static int damage;
    public static int mp = 100;
    public static float TimeDelayHP = 0.4f;
    public static float TimeDelayMP = 0.2f;
    public static float TimeDelayAttack = 0.5f;
    public static int money = 500;
    public static int cristals = 100;
    public static PlayerInfo instance;

    public void Awake()
    {
        if (instance == null) instance = this;
       
    }
    public static void AddMoney(int i)
    {
        foreach (Transform child in HudController.Money.transform)
        {
            if (child.name == "Text")
            {
                i = int.Parse(child.GetComponent<Text>().text) + i;
                child.GetComponent<Text>().text = i.ToString();
            }
        }
    }
    public static void AddCristal(int i)
    {
        foreach (Transform child in HudController.Cristals.transform)
        {
            if (child.name == "Text")
            {
                i = int.Parse(child.GetComponent<Text>().text) + i;
                child.GetComponent<Text>().text = i.ToString();
            }
        }
    }

    public static bool Check(int i, string type)
    {
        if (type == "Money")
            if (money >= i)
                return true;
        if (type == "Cristals")
            if (cristals >= i)
                return true;
        return false;
    }

}
