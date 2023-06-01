using UnityEngine;
using UnityEngine.UI;

public class Swap_class : MonoBehaviour
{
    public GameObject new_class;
    public GameObject Collaider;
    public int k;
    public Sprite []sprite;
    private void Start()
    {
        swap(2);
        

    }
    public void swap()
    { 
        destroy_class();
        k = PlayerInfo.Instance.this_classes;
        if (k < 2) k++;
        else k = 0;
        add_class(k);
        PlayerInfo.Instance.this_classes = k;
    }
    public void swap(int i)
    {
        destroy_class();
        add_class(i);
        PlayerInfo.Instance.this_classes = i;
        OpenInventory.image.sprite = sprite[i];

    }
    public void swap_with_button(Button i)
    {
        destroy_class();
        add_class(int.Parse(i.name));
        OpenInventory.image.sprite = sprite[int.Parse(i.name)];
        string new_name = PlayerInfo.Instance.this_classes.ToString();
        PlayerInfo.Instance.this_classes = int.Parse(i.name);
        i.name = new_name;
        i.GetComponent<Image>().sprite = sprite[int.Parse(new_name)];
    }
    private void destroy_class()
    {
        switch (PlayerInfo.classes[PlayerInfo.Instance.this_classes])
        {
            case "Knight":
                Destroy(gameObject.GetComponent<attack>());
                foreach (Transform child in gameObject.transform)
                {
                    Destroy(child.gameObject);
                }
                break;
            case "Mage":
                foreach (Transform child in gameObject.transform)
                {
                    Destroy(child.gameObject);
                }
                break;
            case "Archer":
                foreach (Transform child in gameObject.transform)
                {
                    Destroy(child.gameObject);
                }
                break;
        }
        if(PlayerInfo.button_atc!=null)
        PlayerInfo.button_atc.onClick.RemoveAllListeners();
    }
    private void add_class(int i)
    {
        switch (PlayerInfo.classes[i])
        {
            case "Knight":
                Player.square.GetComponent<Animator>().runtimeAnimatorController = Instantiate(Resources.Load<RuntimeAnimatorController>("Animations/Square"));
                gameObject.AddComponent<attack>();
                PlayerInfo.button_atc.onClick.AddListener(()=>gameObject.GetComponent<attack>().TaskOnClick());

                break;
            case "Mage":
                Player.square.GetComponent<Animator>().runtimeAnimatorController = Instantiate(Resources.Load<RuntimeAnimatorController>("Animations/Square 1"));
                new_class = Instantiate((GameObject)Resources.Load("Mage"), gameObject.transform);
                PlayerInfo.button_atc.onClick.AddListener(() => new_class.GetComponent<Ñlosest_enemy>().TaskOnClick());

                break;
            case "Archer":
                Player.square.GetComponent<Animator>().runtimeAnimatorController = Instantiate(Resources.Load<RuntimeAnimatorController>("Animations/Square 2"));
                new_class = Instantiate((GameObject)Resources.Load("Mage"), gameObject.transform);
                new_class.GetComponent<Ñlosest_enemy>().splash = (GameObject)Resources.Load("arrow");
                PlayerInfo.button_atc.onClick.AddListener(() => new_class.GetComponent<Ñlosest_enemy>().TaskOnClick());
                break;
        }
    }
}
