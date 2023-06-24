using UnityEngine;
using UnityEngine.UI;

public class Slot_In_BS : MonoBehaviour
{
    public Image Image;
    public Text Name;
    private Recipe _recipe;
    public Button button,buttonInWindow;
    public GameObject recipeWindow;
    public GameObject grid;
    public delegate void Method();
    private Image _imageWindow;
    private string _countText;
    private bool _check;
    private int _count;

    public void Load_Info(Recipe recipe,GameObject grid, GameObject window,Image image,Button button)
    {
        _recipe = recipe;
        Image.sprite = Info.Item_list[recipe.Craftable_item_id].GetComponent<Item>().Icon;
        Name.text = recipe.Name;
        this.grid = grid;
        recipeWindow = window;
        this.button.onClick.AddListener(OpenGrid);
        _imageWindow = image;
        buttonInWindow= button;
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
            _check = _count >= item_Count.Count;
            _countText = _count.ToString()+"/"+ item_Count.Count.ToString();
            gameObject.GetComponent<Frame_Info>().Load_Info(_countText, Info.Item_list[item_Count.Item_id].GetComponent<Item>().Icon, _check, item_Count.Item_id, item_Count.Count);
        }
        buttonInWindow.GetComponentInChildren<Text>().text = _recipe.Cost.ToString();
        buttonInWindow.onClick.RemoveAllListeners();
        buttonInWindow.onClick.AddListener(OnClick);
        recipeWindow.SetActive(true);
    }
    public bool CheckComponents()
    {
        bool check=true;
        foreach (Transform child in grid.transform)
        {
            check = child.GetComponent<Frame_Info>().check && check;
        }
        
        return check;
    }
    public void OnClick()
    {
        
        if (CheckComponents())
        {
            if(PlayerInfo.AddMoney(-_recipe.Cost))
            {
                foreach (Transform child in grid.transform)
                {
                    PlayerInfo.inventory.DeleteItem(child.GetComponent<Frame_Info>().id, child.GetComponent<Frame_Info>().count);

                }
                PlayerInfo.inventory.New_Item(Info.Item_list[_recipe.Craftable_item_id].GetComponent<Item>());
                ReadJSON.Instance.SaveInvenory();
                
            }
             
        }
        else
            Debug.Log("no");
        OpenGrid();
    }
}
