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
        grid = gameObject.transform.Find("Grid").gameObject;
        int i = 0;
        foreach (Transform s in grid.transform)
        {
            
            if(Inventory.InventoryItems.Count>=i+1 && Inventory.InventoryItems[i].Name!="Empty")
            {
                
                s.transform.Find("UIItem").Find("ImageIcon").GetComponent<Image>().sprite = Inventory.InventoryItems[i].Icon;
                s.transform.Find("UIItem").GetComponent<UIItems>().name = Inventory.InventoryItems[i].Name;
                s.transform.Find("UIItem").GetComponent<UIItems>().stack = Inventory.InventoryItems[i].stack;
                s.transform.Find("UIItem").GetComponent<UIItems>().quantity = Inventory.InventoryItems[i].quantity;
                s.transform.Find("UIItem").GetComponent<UIItems>().id = Inventory.InventoryItems[i].id;
                if (Inventory.InventoryItems[i].quantity > 1)
                {
                    s.transform.Find("UIItem").Find("Text").GetComponent<Text>().text = Inventory.InventoryItems[i].quantity.ToString();
                }
                else 
                {
                    s.transform.Find("UIItem").Find("Text").gameObject.SetActive(false);
                }
            }
            else
            {
                s.transform.Find("UIItem").Find("ImageIcon").GetComponent<Image>().gameObject.SetActive(false);
                s.transform.Find("UIItem").Find("Text").gameObject.SetActive(false);
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
            if( s.transform.Find("UIItem")!= null)
            {
                if (s.transform.Find("UIItem").Find("ImageIcon").GetComponent<Image>().gameObject.activeSelf == true)
                {
                    GameObject gameObject = Instantiate(Resources.Load("Item/" + s.transform.Find("UIItem").GetComponent<UIItems>().id.ToString())as GameObject);
                    gameObject.GetComponent<Item>().quantity = s.transform.Find("UIItem").GetComponent<UIItems>().quantity;
                    PlayerInfo.inventory.AddItem(gameObject.GetComponent<Item>());
                    Destroy(gameObject);
                }
                else
                {
                   GameObject gameObject =  Resources.Load("Item/0") as GameObject;
                   PlayerInfo.inventory.AddItem(gameObject.GetComponent<Item>());
                }
            }
            else
            {
                GameObject gameObject = Resources.Load("Item/0") as GameObject;
                PlayerInfo.inventory.AddItem(gameObject.GetComponent<Item>());
            }
        }
        ReadJSON.instance.SaveInvenory();
    }

}
