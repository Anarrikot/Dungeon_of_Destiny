using UnityEngine;
using UnityEngine.UI;

public class OpenInventory : MonoBehaviour
{
    public static Image image;
    void Awake()
    {
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
