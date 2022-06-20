using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<GameObject> StartItems = new List<GameObject>();
    public static List<Item> InventoryItems = new List<Item>();
    // Start is called before the first frame update

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
        Load();
       // foreach (GameObject item in StartItems)
           // AddItem(item.GetComponent<Item>());
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
       Save();
    }
    public void Save()
    {
        List<Item_info> items1 = new List<Item_info>();
        foreach (Item item in InventoryItems)
        {
            Item_info info = new Item_info()
            {
                id = item.id,
                count = item.quantity
            };

            items1.Add(info);
        }
        var data = new WorldData()
        {
            items= items1
        };
        File.WriteAllText(
            "Assets/Resources/Save_Inventory.json",
            JsonConvert.SerializeObject(data,Formatting.Indented, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore})

            );
    }

    public void Load()
    {
        
        WorldData worldData = JsonConvert.DeserializeObject<WorldData>(File.ReadAllText("Assets/Resources/Save_Inventory.json"));
        if(worldData != null)
        {
            foreach (var id in worldData.items)
            { 
                GameObject gameObject = Instantiate(Resources.Load("Item/" + id.id.ToString()) as GameObject);
                gameObject.GetComponent<Item>().quantity = id.count;
                PlayerInfo.inventory.AddItem(gameObject.GetComponent<Item>());
                Destroy(gameObject);
                
            }
        }
    }
}
