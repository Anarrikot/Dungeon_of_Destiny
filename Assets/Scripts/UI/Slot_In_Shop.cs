using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Slot_In_Shop : MonoBehaviour
{
    public Image Icon;
    public GameObject prefab;
    public Item item;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
    }
    public void Load_Info(Item item)
    {
        this.item = item;
        Icon.sprite = item.Icon;
        text.text = item.price.ToString();
        
    }
    public void Buy_Item()
    {
        if(PlayerInfo.AddMoney(-item.price))
            PlayerInfo.inventory.New_Item(item);
        
    }
}
