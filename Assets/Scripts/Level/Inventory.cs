using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<GameObject> StartItems = new List<GameObject>();
    public static List<GameObject> InventoryItems = new List<GameObject>();
    // Start is called before the first frame update

    public void AddItem(GameObject item)
    { 
        InventoryItems.Add(item); 
    }
    private void Start()
    {
        foreach (GameObject item in StartItems)
            AddItem(item);
    }
}
