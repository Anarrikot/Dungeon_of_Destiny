using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


//[CreateAssetMenu(fileName = "ItemData", menuName = "Inventiry/Items")]
public class Item:MonoBehaviour
{
    public string Name = "Item";
    //public Sprite Icon;
    public int quantity = 0;
    public int stack; 
    public int price = 100;
    public Image image;
}
