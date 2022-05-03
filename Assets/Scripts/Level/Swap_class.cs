using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swap_class : MonoBehaviour
{
    public GameObject new_class;
    public int k;

    public void swap()
    { 
        destroy_class();
        k = PlayerInfo.this_classes;
        if (k < 2) k++;
        else k = 0;
        add_class(k);
        PlayerInfo.this_classes = k;
        //add_class(PlayerInfo.classes.Length-PlayerInfo.this_classes-1);
        //PlayerInfo.this_classes = PlayerInfo.classes.Length - PlayerInfo.this_classes-1;

    }
    public void swap(int i)
    {
        destroy_class();
        add_class(i);
        PlayerInfo.this_classes = i;
    }
    private void destroy_class()
    {
        switch (PlayerInfo.classes[PlayerInfo.this_classes])
        {
            case "Knight":
                Destroy(gameObject.GetComponent<attack>());
                foreach (Transform child in gameObject.transform)
                {
                    Destroy(child.gameObject);
                }
                break;
            case "Mage":
                foreach (Transform child in gameObject.transform)
                {
                    Destroy(child.gameObject);
                }
                break;
            case "Archer":
                foreach (Transform child in gameObject.transform)
                {
                    Destroy(child.gameObject);
                }
                break;
        }
        PlayerInfo.button_atc.onClick.RemoveAllListeners();
    }
    private void add_class(int i)
    {
        switch (PlayerInfo.classes[i])
        {
            case "Knight":
                gameObject.AddComponent<attack>();
                PlayerInfo.button_atc.onClick.AddListener(()=>gameObject.GetComponent<attack>().TaskOnClick());
                new_class = Instantiate((GameObject)Resources.Load("Knight_skin"), gameObject.transform);
                break;
            case "Mage":
                new_class=Instantiate((GameObject)Resources.Load("Mage"),gameObject.transform);
                new_class = Instantiate((GameObject)Resources.Load("Mage_skin"), gameObject.transform);
                PlayerInfo.button_atc.onClick.AddListener(() => new_class.GetComponent<Ñlosest_enemy>().TaskOnClick());
                break;
            case "Archer":
                new_class = Instantiate((GameObject)Resources.Load("Archer_skin"), gameObject.transform);
                new_class = Instantiate((GameObject)Resources.Load("Mage"), gameObject.transform);
                new_class.GetComponent<Ñlosest_enemy>().splash = (GameObject)Resources.Load("arrow");
                PlayerInfo.button_atc.onClick.AddListener(() => new_class.GetComponent<Ñlosest_enemy>().TaskOnClick());
                break;
        }
    }
}
