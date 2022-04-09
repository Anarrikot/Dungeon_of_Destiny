using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HudController : MonoBehaviour
{
    public static GameObject Money, Cristals,HUD;

    public void Show()
    {
        Money = (GameObject)Resources.Load("Money");
        Cristals = (GameObject)Resources.Load("Cristals");
        Money = Main.Instantiate(Money, Main.instance.HUD.transform);
        Cristals = Main.Instantiate(Cristals, Main.instance.HUD.transform);
        foreach (Transform child in Money.transform)
        {
            if (child.name == "Text")
            {
                child.GetComponent<Text>().text = PlayerInfo.money.ToString();
            }
        }
        foreach (Transform child in Cristals.transform)
        {
            if (child.name == "Text")
            {
                child.GetComponent<Text>().text = PlayerInfo.cristals.ToString();
            }
        }
        HUD=Instantiate((GameObject)Resources.Load("Stats_in_HUD"), Main.instance.HUD.transform);
        foreach(Transform child in HUD.transform)
        {
            if(child.name == "MP")
                PlayerInfo.MP_Image=child.GetComponent<Image>();
            if (child.name == "HP")
                PlayerInfo.HP_Image = child.GetComponent<Image>();
        }
    }

}
 