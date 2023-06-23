using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Frame_Info : MonoBehaviour
{
    public Text text;
    public Image image;
    public bool check;
    public int id, count;
    public void Load_Info(string text, Sprite image,bool check,int id,int count)
    {
        this.text.text = text;
        this.image.sprite = image;
        this.check = check;
        this.id = id;
        this.count = count;
    }
}
