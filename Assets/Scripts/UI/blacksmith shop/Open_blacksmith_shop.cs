using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using UnityEngine.UI;
public class Recipe
{
    public string Name;
    public int id;
    public int Cost;
    public int Craftable_item_id;
    
    public List<Item_count> Components;
}
public class WorldData<T>
{
    public List<T> user = new List<T>();
}
public class Item_count
{
    public int Count;
    public int Item_id;
}

public class Open_blacksmith_shop : MonoBehaviour
{
    public GameObject grid;
    public List<Recipe> Recipes = new List<Recipe>();
    public GameObject RecipeImage;
    public GameObject MaterialsList;
    public GameObject RecipeWindow;
    public Button buttonInWindow;
    public Image ImageWindow; 


    void Start()
    {
        Recipes = ReadJSON.Instance.Load2<Recipe>("Save_Recipe");
        foreach (Recipe recipe in Recipes)
        {
            GameObject gameObject = Instantiate(Resources.Load("Blacksmith/Recipe") as GameObject, grid.transform);
            gameObject.GetComponent<Slot_In_BS>().Load_Info(recipe,MaterialsList, RecipeWindow, ImageWindow, buttonInWindow);
        }
          
    }
    public void Close_BS()
    {
        Destroy(gameObject);
    }
}
