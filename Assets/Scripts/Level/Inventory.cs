using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<GameObject> StartItems = new List<GameObject>();
    public static List<Item> InventoryItems = new List<Item>();

    public class Item_info
    {
        public int id = new int();
        public int count = new int();
    }
    public class WorldData
    {
      public List<Item_info> items = new List<Item_info>(); 
    }

    public void AddItem(Item prefab)
    {
        Item item= new Item();
        item.Name = prefab.Name;
        item.price = prefab.price;
        item.quantity = prefab.quantity;
        item.stack = prefab.stack;
        item.id = prefab.id;
        if (prefab.Icon != null)
            item.Icon = prefab.Icon;
        InventoryItems.Add(item);
    }
    private void Start()
    {
        ReadJSON.Instance.Load("Save_Inventory");
    }
    public void New_Item(Item new_item)
    {
        int Empty_slot=-1;
        bool check = false;
        foreach (Item item in InventoryItems)
        {
            if (!check)
            {
                Empty_slot++;
            }

            if (item.Name == new_item.Name&&item.quantity+new_item.quantity<=item.stack)
            {
                item.quantity++;
                return;
            }
            if(item.Name == "Empty")
            {
                check = true;
            }
        }
       
        if (InventoryItems.Count>=Empty_slot+2)
        {
            
            InventoryItems[Empty_slot].Name = new_item.Name;
            InventoryItems[Empty_slot].price = new_item.price;
            InventoryItems[Empty_slot].quantity = new_item.quantity;
            InventoryItems[Empty_slot].stack = new_item.stack;
            InventoryItems[Empty_slot].id = new_item.id;
            if(new_item.Icon!=null)
                InventoryItems[Empty_slot].Icon = new_item.Icon;
        }
        else
        {
            
            AddItem(new_item.GetComponent<Item>());
        }
      
    }
    public void Save()
    {
        ReadJSON.Instance.SaveInvenory();
    }
}
