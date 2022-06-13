using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<GameObject> StartItems = new List<GameObject>();
    public static List<Item> InventoryItems = new List<Item>();
    // Start is called before the first frame update

    public void AddItem(GameObject prefab)
    {
        Item item= new Item();
        item.Name = prefab.GetComponent<Item>().Name;
        item.price = prefab.GetComponent<Item>().price;
        item.quantity = prefab.GetComponent<Item>().quantity;
        item.stack = prefab.GetComponent<Item>().stack;
        item.id = prefab.GetComponent<Item>().id;
        item.Icon = prefab.GetComponent<Item>().Icon;
        InventoryItems.Add(item);
    }
    private void Start()
    {
        foreach (GameObject item in StartItems)
            AddItem(item);
    }
    public void New_Item(GameObject new_item)
    {
        int Empty_slot=-1;
        bool check = false;
        foreach (Item item in InventoryItems)
        {
            if (!check)
            {
                Empty_slot++;

            }
            if (item.Name == new_item.GetComponent<Item>().Name)
            {
                item.quantity++;
                return;
            }
            if(item.Name == "Empty")
            {
                check = true;
            }
        }

        if (Empty_slot>0)
        {
            
            InventoryItems[Empty_slot].Name = new_item.GetComponent<Item>().Name;
            InventoryItems[Empty_slot].price = new_item.GetComponent<Item>().price;
            InventoryItems[Empty_slot].quantity = new_item.GetComponent<Item>().quantity;
            InventoryItems[Empty_slot].stack = new_item.GetComponent<Item>().stack;
            InventoryItems[Empty_slot].id = new_item.GetComponent<Item>().id;
            InventoryItems[Empty_slot].Icon = new_item.GetComponent<Item>().Icon;
        }
        else
        {
            AddItem(new_item);
        }

    }
}
