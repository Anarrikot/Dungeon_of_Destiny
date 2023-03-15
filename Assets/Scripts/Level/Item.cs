using UnityEngine;
using UnityEngine.UI;

public class Item:MonoBehaviour
{
    public string Name = "Item";
    public int quantity = 0;
    public int stack; 
    public int price = 100;
    public Sprite Icon;
    public Image image;
    public int id;
    public void Start()
    {
        if(gameObject.GetComponent<Sprite>() != null)
        {
            Icon = gameObject.GetComponent<Sprite>();
        }
    }
}
