using UnityEngine;


public class OpenShop : MonoBehaviour
{
    public GameObject grid;
    void Start()
    {
        for (int i = 1; i <= Info.Item_list.Count-1; i++)
        {
            GameObject gameObject= Instantiate(Resources.Load("Shop/Item") as GameObject, grid.transform);
            gameObject.GetComponent<Slot_In_Shop>().Load_Info(Info.Item_list[i]);
            
        }
    }
    public void Close_shop()
    {
        Destroy(gameObject);
    }
}
