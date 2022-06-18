using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Info : MonoBehaviour
{
    public static Info instance;
    public static List<Item> Item_list = new List<Item>();
    void Start()
    {

    }
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
