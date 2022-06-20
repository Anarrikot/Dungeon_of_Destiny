using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenInventory : MonoBehaviour
{
    public static Image image;
    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log("fff");
        foreach (Transform child in gameObject.transform)
        {
            if (child.name == "Icon")
                image = child.GetComponent<Image>();
        }
    }
    public void Open()
    {
        Main.instance.TaskOnClick();
    }
}
