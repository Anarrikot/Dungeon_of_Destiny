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
        if(prefab.GetComponent<Item>().image!=null)
            item.Icon= prefab.GetComponent<Item>().image.sprite;
        InventoryItems.Add(item);
    }
    private void Start()
    {
        foreach (GameObject item in StartItems)
            AddItem(item);

    }
}
