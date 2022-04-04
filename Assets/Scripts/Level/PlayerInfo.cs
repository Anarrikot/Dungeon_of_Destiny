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
    public static PlayerInfo instance;
    public static GameObject M, C;

    public void Awake()
    {
        if (instance == null) instance = this;
       
    }
    public void Start()
    {
        M = (GameObject)Resources.Load("Money");
        C = (GameObject)Resources.Load("Cristals");
        M=Main.Instantiate(M, Main.instance.windowCanvas.transform);
        C=Main.Instantiate(C, Main.instance.windowCanvas.transform);
        foreach(Transform child in M.transform)
        {
            if(child.name =="Text")
            {
                child.GetComponent<Text>().text = "0";
            }
        }
        foreach (Transform child in C.transform)
        {
            if (child.name == "Text")
            {
                child.GetComponent<Text>().text = "0";
            }
        }
    }

    public static void CheckMoney(int i)
    {
        foreach (Transform child in M.transform)
        {
            if (child.name == "Text")
            {
                i = int.Parse(child.GetComponent<Text>().text) + i;
                child.GetComponent<Text>().text = i.ToString();
            }
        }
    }
    public static void CheckCristal(int i)
    {
        foreach (Transform child in M.transform)
        {
            if (child.name == "Text")
            {
                i = int.Parse(child.GetComponent<Text>().text) + 4;
                child.GetComponent<Text>().text = i.ToString();
            }
        }
    }
}
