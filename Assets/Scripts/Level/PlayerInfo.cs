using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    public static int lives = 100;
    public static int livesMax = 100;
    public static int uid = 123;
    public static int money = 500;
    public static int cristals = 100;
    public static int damage;
    public static int mp = 100;
    public static int this_classes;
    public static float speed = 10, x, y;
    public static float TimeDelayHP = 0.4f;
    public static float TimeDelayMP = 0.01f;
    public static float TimeDelayAttack = 0.1f;
    public static string name;
    public static PlayerInfo instance;
    public static string[] classes = new string[3];
    public static Button button_atc;
    public static Image HP_Image, MP_Image;
    public static Inventory inventory= new Inventory();
    private static Transform moneyText;
    private static Transform cristalsText;

    public static void Start_Set()
    {
        foreach (Transform child in HudController.Money.transform)
        {
           moneyText=child;
        }
        foreach (Transform child in HudController.Cristals.transform)
        {
            cristalsText = child;
        }
    }
    public static void SetMoney(int m)
    {
        money = m;
        moneyText.GetComponent<Text>().text = money.ToString();
    }
    public static void SetCristals(int m)
    {
        cristals = m;
        cristalsText.GetComponent<Text>().text = cristals.ToString();
    }
    public void Awake()
    {
        if (instance == null) instance = this;
        classes[0] = "Archer";
        classes[1] = "Mage";
        classes[2] = "Knight";
        this_classes = 0;
    }
    public static bool AddMoney(int i)
    {
        if (Check(i,"Money"))
        {
            money += i;
            i = int.Parse(moneyText.GetComponent<Text>().text) + i;
            moneyText.GetComponent<Text>().text = i.ToString();
            SetMoney(money);
            return true;
        }
        return false;
    }
    public static bool AddCristal(int i) { 

        if (Check(i, "Cristals"))
        {
            cristals += i;
            i = int.Parse(cristalsText.GetComponent<Text>().text) + i;
            cristalsText.GetComponent<Text>().text = i.ToString();
            SetCristals(cristals);
            return true;
        }
        return false;
    }

    public static bool Check(int i, string type)
    {
        
        if (type == "Money")
            if (money >= Mathf.Abs(i))
                return true;   
        if (type == "Cristals")
            if (cristals >= Mathf.Abs(i))
                return true;
       
        Main.instance.Notification();
        return false;
    }
}
