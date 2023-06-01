using System.Collections.Generic;
using UnityEngine;


public class Info : MonoBehaviour
{
    public static List<Item> Item_list = new List<Item>();


    private static Info _instance;
    public static Info Instance
        => _instance ??= new Info();

    public Info()
    {
        _instance = this;
    }

    public void Add_Item(Item item)
    {
        Item_list.Add(item);
    }
    public void Awake()
    {
        for (int i = 0; i <= 2; i++)
        {
            GameObject gameObject = Resources.Load("Item/" + i.ToString()) as GameObject;
            Add_Item(gameObject.GetComponent<Item>());
        }
    }
}
