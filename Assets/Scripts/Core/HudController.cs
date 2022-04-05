using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HudController : MonoBehaviour
{
    public static GameObject Money, Cristals;

    public void Show()
    {
        Money = (GameObject)Resources.Load("Money");
        Cristals = (GameObject)Resources.Load("Cristals");
        Money = Main.Instantiate(Money, Main.instance.windowCanvas.transform);
        Cristals = Main.Instantiate(Cristals, Main.instance.windowCanvas.transform);
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
    }

}
 