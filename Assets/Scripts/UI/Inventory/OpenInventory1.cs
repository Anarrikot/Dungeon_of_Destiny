using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenInventory1 : MonoBehaviour
{
    public GameObject grid;
    public Text hpText;
    public Text manaText;
    public Text damageText;
    public Text armorText;
    public Button knigth;
    public Button archer;
    public Button mag;
    Item Item;
    
    [SerializeField]List<GameObject> list = new List<GameObject>();
    void Start()
    {
        hpText.text = PlayerInfo.khigth.livesMax.ToString();
        manaText.text = PlayerInfo.khigth.mp.ToString();
        damageText.text = PlayerInfo.khigth.damage.ToString();
        armorText.text = PlayerInfo.khigth.armor.ToString() + "%";
        grid = gameObject.transform.Find("Grid").gameObject;
        knigth.GetComponent<Image>().color = Color.green;
        int i = 0;
        foreach (Transform s in grid.transform)
        {
            
            if(Inventory.InventoryItems.Count>=i+1 && Inventory.InventoryItems[i].Name!="Empty")
            {
                
                s.transform.Find("UIItem").Find("ImageIcon").GetComponent<Image>().sprite = Inventory.InventoryItems[i].Icon;
                if (s.transform.Find("UIItem").TryGetComponent<UIItems>(out var s1))
                {
                    s1.name = Inventory.InventoryItems[i].Name;
                    s1.stack = Inventory.InventoryItems[i].stack;
                    s1.quantity = Inventory.InventoryItems[i].quantity;
                    s1.id = Inventory.InventoryItems[i].id;

                }
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
        ReadJSON.Instance.SaveInvenory();
    }

    public void buttomKnigth() 
    {
        hpText.text = PlayerInfo.khigth.livesMax.ToString();
        manaText.text = PlayerInfo.khigth.mp.ToString();
        damageText.text = PlayerInfo.khigth.damage.ToString();
        armorText.text = PlayerInfo.khigth.armor.ToString() + "%";
        knigth.GetComponent<Image>().color = Color.green;
        archer.GetComponent<Image>().color = Color.white;
        mag.GetComponent<Image>().color = Color.white;
    }
    public void buttomArcher()
    {
        hpText.text = PlayerInfo.archer.livesMax.ToString();
        manaText.text = PlayerInfo.archer.mp.ToString();
        damageText.text = PlayerInfo.archer.damage.ToString();
        armorText.text = PlayerInfo.archer.armor.ToString() + "%";
        archer.GetComponent<Image>().color = Color.green;
        knigth.GetComponent<Image>().color = Color.white;
        mag.GetComponent<Image>().color = Color.white;
    }
    public void buttomMag()
    {
        hpText.text = PlayerInfo.mag.livesMax.ToString();
        manaText.text = PlayerInfo.mag.mp.ToString();
        damageText.text = PlayerInfo.mag.damage.ToString();
        armorText.text = PlayerInfo.mag.armor.ToString() + "%";
        mag.GetComponent<Image>().color = Color.green;
        archer.GetComponent<Image>().color = Color.white;
        archer.GetComponent<Image>().color = Color.white;
    }
}
