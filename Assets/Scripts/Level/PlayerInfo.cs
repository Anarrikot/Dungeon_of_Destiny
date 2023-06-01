using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    public int lives = 100;
    public int livesMax = 100;
    public int uid = 123;
    public int money = 500;
    public int cristals = 100;
    public int damage;
    public int mp = 100;
    public int this_classes;
    public float speed = 10, x, y;
    public float TimeDelayHP = 0.4f;
    public float TimeDelayMP = 0.01f;
    public float TimeDelayAttack = 0.1f;
    public string name;
    
    public static string[] classes = new string[3];
    public static Button button_atc;
    public static Image HP_Image, MP_Image;
    public static Inventory inventory= new Inventory();
    private static Text moneyText;
    private static Text cristalsText;




    private static PlayerInfo _instance;
    public static PlayerInfo Instance
        => _instance ??= new PlayerInfo();

    public PlayerInfo()
    {
        _instance = this;
    }

    public static void Start_Set()
    {
        foreach (Transform child in HudController.Money.transform)
        {
           moneyText= child.GetComponent<Text>();
        }
        foreach (Transform child in HudController.Cristals.transform)
        {
            cristalsText = child.GetComponent<Text>();
        }
    }
    public static void SetMoney(int m)
    {
        Instance.money = m;
        moneyText.text = Instance.money.ToString();
    }
    public static void SetCristals(int m)
    {
        Instance.cristals = m;
        cristalsText.text = Instance.cristals.ToString();
    }
    public void Awake()
    {
        
        classes[0] = "Archer";
        classes[1] = "Mage";
        classes[2] = "Knight";
        this_classes = 0;
    }
    public static bool AddMoney(int i)
    {
        if (Check(i,"Money"))
        {
            Instance.money += i;
            i = int.Parse(moneyText.text) + i;
            moneyText.text = i.ToString();
            SetMoney(Instance.money);
            return true;
        }
        return false;
    }
    public static bool AddCristal(int i) { 

        if (Check(i, "Cristals"))
        {
            Instance.cristals += i;
            i = int.Parse(cristalsText.text) + i;
            cristalsText.text = i.ToString();
            SetCristals(Instance.cristals);
            return true;
        }
        return false;
    }

    public static bool Check(int i, string type)
    {
        
        if (type == "Money")
            if (Instance.money >= Mathf.Abs(i))
                return true;   
        if (type == "Cristals")
            if (Instance.cristals >= Mathf.Abs(i))
                return true;
       
        Main.Instance.Notification();
        return false;
    }
}
