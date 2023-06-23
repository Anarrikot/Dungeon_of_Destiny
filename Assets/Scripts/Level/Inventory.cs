using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<GameObject> StartItems = new List<GameObject>();
    public static List<Item> InventoryItems = new List<Item>();
    private int _count;
    public class Item_info
    {
        public int id = new int();
        public int count = new int();
    }
    public class WorldData
    {
      public List<Item_info> items = new List<Item_info>(); 
    }
    private void Update()
    {
       
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
    public void DeleteItem(int id,int count)
    {
        if (InventoryItems.Count != 0)
        {
            foreach (Item item in InventoryItems)
            {
                if (count > 0)
                {
                    if (item.id == id&& item.quantity>=count)
                    {
                        item.quantity -= count;
                        if (item.quantity <= 0)
                        {
                            item.Name = "Empty";
                            item.id = 0;
                        }
                    }
                }
                else
                    return;
                
            }
        }
    }
    public int CheckItem(int id)
    {
        _count = 0;
        if (InventoryItems.Count != 0)
        {
            foreach (Item item in InventoryItems)
            {
                if (item.id == id)
                {
                    _count += item.quantity; 
                }
            } 
        }
        return _count;
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
