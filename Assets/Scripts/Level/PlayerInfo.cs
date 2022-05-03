using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    public static int lives = 100;
    public static float speed = 10,x,y;
    public static int damage;
    public static int mp = 100;
    public static float TimeDelayHP = 0.4f;
    public static float TimeDelayMP = 0.2f;
    public static float TimeDelayAttack = 0.1f;
    public static int money = 500;
    public static int cristals = 100;
    public static PlayerInfo instance;
    public static string[] classes = new string[3];
    public static int this_classes;
    public static Button button_atc;
    public static Image HP_Image, MP_Image;

    public void Awake()
    {
        if (instance == null) instance = this;
        classes[0] = "Archer";
        classes[1] = "Mage";
        classes[2] = "Knight";
        this_classes = 0;
    }
    public void Start()
    {

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
