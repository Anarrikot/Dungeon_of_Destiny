using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactions : MonoBehaviour
{
    //public Player player;
    private GameObject npc;
    public GameObject button;
    public Sprite one, two;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Enemy" && collision.gameObject.tag != "Untagged")
        {
            second_button();
            npc = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Enemy" && collision.gameObject.tag != "Untagged")
        {
            npc = null;
            first_button();
        }

    }
    public void TaskOnClick()
    {
        if (npc != null)
        {

            switch (npc.tag)
            {
                case "Transition":
                    npc.GetComponent<Tunnel>().action();
                    break;
            }
        }
    }
    public void first_button()
    {
        button.GetComponent<Image>().sprite = one;
    }
    public void second_button()
    {
        button.GetComponent<Image>().sprite = two;
    }
}
