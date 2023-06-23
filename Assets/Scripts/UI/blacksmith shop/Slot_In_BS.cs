using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot_In_BS : MonoBehaviour
{
    public Image Image;
    public Text Name;
    private Recipe _recipe;
    public Button button;
    public GameObject recipeWindow;
    public GameObject grid;
    public delegate void Method();
    private Image _imageWindow;
    private string _countText;
    private bool _check;
    private int _count;

    public void Load_Info(Recipe recipe,GameObject grid, GameObject window,Image image)
    {
        _recipe = recipe;
        Image.sprite = Info.Item_list[recipe.Craftable_item_id].GetComponent<Item>().Icon;
        Name.text = Info.Item_list[recipe.Craftable_item_id].GetComponent<Item>().Name;
        this.grid = grid;
        recipeWindow = window;
        button.onClick.AddListener(OpenGrid);
        _imageWindow = image;
    }

    public void OpenGrid()
    {
        foreach (Transform child in grid.transform)
        {
            Destroy(child.gameObject);
        }
        _imageWindow.sprite = Image.sprite;
        foreach(Item_count item_Count in _recipe.Components)
        {
            GameObject gameObject = Instantiate(Resources.Load("Blacksmith/Frame") as GameObject, grid.transform);
            _count = PlayerInfo.inventory.CheckItem(item_Count.Item_id);
            _check = PlayerInfo.inventory.CheckItem(item_Count.Item_id) > item_Count.Count;
            _countText = PlayerInfo.inventory.CheckItem(item_Count.Item_id).ToString()+"/"+ item_Count.Count.ToString();

            gameObject.GetComponent<Frame_Info>().Load_Info(_countText, Info.Item_list[item_Count.Item_id].GetComponent<Item>().Icon,true);
        }
        recipeWindow.SetActive(true);
    }
}
