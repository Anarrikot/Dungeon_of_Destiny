using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    public int uid = 111111111;
    public int money = 500;
    public int cristals = 100;
    public int this_classes;
    public float speed = 10, x, y;
    public string name;
    
    public static string[] classes = new string[3];
    public static Button button_atc;
    public static Image HP_Image, MP_Image;
    public static Inventory inventory= new Inventory();
    private static Text moneyText;
    private static Text cristalsText;
    public static ClassInfo khigth = new ClassInfo() { lives = 200, livesMax = 200, mp = 100, mpMax = 100, damage = 20, armor = 5, TimeDelayAttack = 0.1f, TimeDelayHP =  0.4f, TimeDelayMP = 0.01f};
    public static ClassInfo archer = new ClassInfo() { lives = 100, livesMax = 100, mp = 100, mpMax = 100, damage = 30, armor = 1, TimeDelayAttack = 0.1f, TimeDelayHP = 0.4f, TimeDelayMP = 0.01f };
    public static ClassInfo mag = new ClassInfo() { lives = 100, livesMax = 100, mp = 300, mpMax=300, damage = 20, armor = 1, TimeDelayAttack = 0.1f, TimeDelayHP = 0.4f, TimeDelayMP = 0.01f };



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

    public static void AddMoneyPlayer(int i)
    {
            Instance.money += i;
            i = int.Parse(moneyText.text) + i;
            moneyText.text = i.ToString();
            SetMoney(Instance.money);
    }
    public static void AddCristalPlayer(int i)
    {
            Instance.cristals += i;
            i = int.Parse(cristalsText.text) + i;
            cristalsText.text = i.ToString();
            SetCristals(Instance.cristals);
    }
}
