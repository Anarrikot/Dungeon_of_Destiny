using System.Collections.Generic;
using UnityEngine;


public class Info : MonoBehaviour
{
    public static Info instance;
    public static List<Item> Item_list = new List<Item>();

    public void Add_Item(Item item)
    {
        Item_list.Add(item);
    }
    public void Awake()
    {
        if (instance == null) instance = this;
        for (int i = 0; i <= 2; i++)
        {
            GameObject gameObject = Resources.Load("Item/" + i.ToString()) as GameObject;
            Add_Item(gameObject.GetComponent<Item>());
        }
    }
}
