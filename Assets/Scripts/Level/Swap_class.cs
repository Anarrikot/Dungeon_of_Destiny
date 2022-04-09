using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swap_class : MonoBehaviour
{
    public GameObject new_class;
    public void swap()
    {
        
        destroy_class();
        add_class(PlayerInfo.classes.Length-PlayerInfo.this_classes-1);
        PlayerInfo.this_classes = PlayerInfo.classes.Length - PlayerInfo.this_classes-1;
    }
    private void destroy_class()
    {
        switch (PlayerInfo.classes[PlayerInfo.this_classes])
        {
            case "Knight":
                Destroy(gameObject.GetComponent<attack>());
                break;
            case "Mage":
                foreach (Transform child in gameObject.transform)
                {
                    Destroy(child.gameObject);
                }
                break;
        }
        Debug.Log(PlayerInfo.button_atc);
        PlayerInfo.button_atc.onClick.RemoveAllListeners();
    }
    private void add_class(int i)
    {
        switch (PlayerInfo.classes[i])
        {
            case "Knight":
                gameObject.AddComponent<attack>();
                PlayerInfo.button_atc.onClick.AddListener(()=>gameObject.GetComponent<attack>().TaskOnClick());

                break;
            case "Mage":
                new_class=Instantiate((GameObject)Resources.Load("Mage"),gameObject.transform);
                PlayerInfo.button_atc.onClick.AddListener(() => new_class.GetComponent<Ñlosest_enemy>().TaskOnClick());
                break;
        }
    }
}
