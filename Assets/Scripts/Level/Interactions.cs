using UnityEngine;
using UnityEngine.UI;

public class Interactions : MonoBehaviour
{
    private GameObject npc;
    public GameObject button;
    public Sprite one, two;
    private Sprite _buttonSprite;

    public void Start()
    {
        _buttonSprite = button.GetComponent<Image>().sprite;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Enemy" && collision.gameObject.tag != "Untagged" && collision.gameObject.tag != "Wall")
        {
            second_button();
            npc = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Enemy" && collision.gameObject.tag != "Untagged" && collision.gameObject.tag != "Wall")
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
        _buttonSprite = one;
    }
    public void second_button()
    {
        _buttonSprite = two;
    }
}
