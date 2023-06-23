using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class ReadJSON : MonoBehaviour
{
    private static ReadJSON _instance;
    public static ReadJSON Instance
        => _instance ??= new ReadJSON();

    public ReadJSON()
    {
        _instance = this;
    }

    private void Start()
    {
        Load("Save_Inventory");
    }
    public class WorldData<T>
    {
        public List<T> user = new List<T>();
    }
    public class Item_info
    {
        public int id = new int();
        public int count = new int();
    }
    public class Info
    {
        public string name; 
        public int uid = new int();
        public int soft = new int();
        public int hard = new int();
    }
    public List<T> Load2<T>(string Name)
    {
        WorldData<T> worldData = JsonConvert.DeserializeObject<WorldData<T>>(File.ReadAllText("Assets/Resources/" + Name + ".json"));
        return worldData.user;

        //T wData = JsonConvert.DeserializeObject<T>(File.ReadAllText("Assets/Resources/" + Name + ".json"));
        //return wData;
    }
    public void Load(string Name)
    {      
        if(Name== "Save_Inventory")
        {
            WorldData<Item_info> worldData = JsonConvert.DeserializeObject<WorldData<Item_info>>(File.ReadAllText("Assets/Resources/" + Name + ".json"));
            if (worldData != null)
            {
                foreach (var id in worldData.user)
                {
                    GameObject gameObject = Instantiate(Resources.Load("Item/" + id.id.ToString()) as GameObject);
                    gameObject.GetComponent<Item>().quantity = id.count;
                    PlayerInfo.inventory.AddItem(gameObject.GetComponent<Item>());
                    Destroy(gameObject);
                }
            }  
        }
        if (Name == "Save_Info")
        {
            WorldData<Info> worldData = JsonConvert.DeserializeObject<WorldData<Info>>(File.ReadAllText("Assets/Resources/" + Name + ".json"));

            PlayerInfo.Instance.name = worldData.user[0].name;
            PlayerInfo.Instance.uid = worldData.user[0].uid;
            PlayerInfo.Instance.money = worldData.user[0].soft;
            PlayerInfo.Instance.cristals = worldData.user[0].hard;
        }
    }
    public void SaveInvenory()
    {
        List<Item_info> items1 = new List<Item_info>();
        foreach (Item item in Inventory.InventoryItems)
        {
            Item_info info = new Item_info()
            {
                id = item.id,
                count = item.quantity
            };

            items1.Add(info);
        }
        var data = new WorldData<Item_info>()
        {
            user = items1
        };
        File.WriteAllText(
            "Assets/Resources/Save_Inventory.json",
            JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })

            );
    }
    public void SaveInfo()
    {
        List<Info> items1 = new List<Info>();

        Info info = new Info()
        {
            name = PlayerInfo.Instance.name,
            uid = PlayerInfo.Instance.uid,
            soft = PlayerInfo.Instance.money,
            hard = PlayerInfo.Instance.cristals,
        };

        items1.Add(info);
        var data = new WorldData<Info>()
        {
            user = items1
        };
        File.WriteAllText(
            "Assets/Resources/Save_Info.json",
            JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
    }
    public void SaveRecipe(List<Recipe> recipe_list)
    {

        var data = new WorldData<Recipe>()
        {
            user = recipe_list
        };
        Debug.Log(recipe_list);
        File.WriteAllText(
            "Assets/Resources/Save_Recipe.json",
            JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })

            );

    }
}
