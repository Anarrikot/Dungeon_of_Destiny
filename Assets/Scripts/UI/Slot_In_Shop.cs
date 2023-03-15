using UnityEngine;
using UnityEngine.UI;

public class Slot_In_Shop : MonoBehaviour
{
    public Image Icon;
    public GameObject prefab;
    public Item item;
    public Text text;

    void Start()
    {
    }
    public void Load_Info(Item item)
    {
        this.item = item;
        Icon.sprite = item.Icon;
        text.text = item.price.ToString();
        
    }
    public async void Buy_Item()
    {
        if(PlayerInfo.money>=item.price)
        {
            GetInfo.verified = false;
            await GetInfo.instance.ReturnInfo("http://game.ispu.ru/game1/dod/api.php?api=buyItem&uid="+PlayerInfo.uid.ToString()+"&soft="+item.price.ToString()+"&id="+item.id.ToString(), item.price);
            if (GetInfo.verified)
            {
                PlayerInfo.AddMoney(-item.price);
                PlayerInfo.inventory.New_Item(item);
                ReadJSON.instance.SaveInvenory();
            }
        }       
    }
}
