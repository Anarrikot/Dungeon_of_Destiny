using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swap_class : MonoBehaviour
{
    public GameObject new_class;
    public GameObject Collaider;
    public int k;

    public void swap()
    { 
        destroy_class();
        k = PlayerInfo.this_classes;
        if (k < 2) k++;
        else k = 0;
        add_class(k);
        PlayerInfo.this_classes = k;
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
                Player.square.GetComponent<Animator>().runtimeAnimatorController = Instantiate(Resources.Load<RuntimeAnimatorController>("Animations/Square 2"));
                gameObject.AddComponent<attack>();
                PlayerInfo.button_atc.onClick.AddListener(()=>gameObject.GetComponent<attack>().TaskOnClick());
                //Player.square = (GameObject)Resources.Load("Knight_skin");
                break;
            case "Mage":
                Player.square.GetComponent<Animator>().runtimeAnimatorController = Instantiate(Resources.Load<RuntimeAnimatorController>("Animations/Square 1"));
                //Player.New_skin((GameObject)Resources.Load("Mage_S")); 
                // Player.square = (GameObject)Resources.Load("Mage_S");
                new_class = Instantiate((GameObject)Resources.Load("Mage"), gameObject.transform);
                PlayerInfo.button_atc.onClick.AddListener(() => new_class.GetComponent<Ñlosest_enemy>().TaskOnClick());

                break;
            case "Archer":
               
                Player.square.GetComponent<Animator>().runtimeAnimatorController = Instantiate(Resources.Load<RuntimeAnimatorController>("Animations/Square"));
                //Player.New_skin((GameObject)Resources.Load("Archer_S")); 
                //Player.square = (GameObject)Resources.Load("Archer_S");
                new_class = Instantiate((GameObject)Resources.Load("Mage"), gameObject.transform);
                new_class.GetComponent<Ñlosest_enemy>().splash = (GameObject)Resources.Load("arrow");
                PlayerInfo.button_atc.onClick.AddListener(() => new_class.GetComponent<Ñlosest_enemy>().TaskOnClick());
                break;
        }
        //Player.animator=Player.square.GetComponent<Animator>();
    }
}
