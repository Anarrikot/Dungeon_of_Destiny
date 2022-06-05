using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class OpenInventory1 : MonoBehaviour
{
    public GameObject grid;
    Item Item;
    
    [SerializeField]List<GameObject> list = new List<GameObject>();
    void Start()
    {
        grid = gameObject.transform.FindChild("Grid").gameObject;
        int i = 0;
        foreach (Transform s in grid.transform)
        {
            
            if(Inventory.InventoryItems.Count>=i+1 && Inventory.InventoryItems[i].Name!="Empty")
            {
                
                s.transform.FindChild("UIItem").FindChild("ImageIcon").GetComponent<Image>().sprite = Inventory.InventoryItems[i].Icon;
                s.transform.FindChild("UIItem").GetComponent<UIItems>().name = Inventory.InventoryItems[i].Name;
                s.transform.FindChild("UIItem").GetComponent<UIItems>().stack = Inventory.InventoryItems[i].stack;
                s.transform.FindChild("UIItem").GetComponent<UIItems>().quantity = Inventory.InventoryItems[i].quantity;
                if (Inventory.InventoryItems[i].quantity > 1)
                {
                    s.transform.FindChild("UIItem").FindChild("Text").GetComponent<Text>().text = Inventory.InventoryItems[i].quantity.ToString();
                }
                else 
                {
                    s.transform.FindChild("UIItem").FindChild("Text").gameObject.SetActive(false);
                }
            }
            else
            {
                s.transform.FindChild("UIItem").FindChild("ImageIcon").GetComponent<Image>().gameObject.SetActive(false);
                s.transform.FindChild("UIItem").FindChild("Text").gameObject.SetActive(false);
            }
            list.Add(s.gameObject);
            i++;
        }
    }
    public void save()
    {
        Inventory.InventoryItems.Clear();   
        foreach (GameObject s in list)
        {
            if( s.transform.FindChild("UIItem")!= null)
            {
                if (s.transform.FindChild("UIItem").FindChild("ImageIcon").GetComponent<Image>().gameObject.activeSelf == true)
                {
                    GameObject gameObject = Instantiate(Resources.Load("Item/" + s.transform.FindChild("UIItem").GetComponent<UIItems>().name) as GameObject);
                    gameObject.GetComponent<Item>().quantity = s.transform.FindChild("UIItem").GetComponent<UIItems>().quantity;
                    PlayerInfo.inventory.AddItem(gameObject);
                }
                else
                {
                   PlayerInfo.inventory.AddItem(Instantiate(Resources.Load("Item/Empty") as GameObject));
                }
            }
            else
            {
                PlayerInfo.inventory.AddItem(Instantiate(Resources.Load("Item/Empty") as GameObject));
            }
        }
    }

}
