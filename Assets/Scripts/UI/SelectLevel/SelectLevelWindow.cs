using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevelWindow: MonoBehaviour 
    
{
    public List<GameObject> Stars = new List<GameObject>();
    public GameObject name;
    
    public GameObject window;
    private int StarsQuantity = 0;
    private int LevelNumber = 0;
    private void Awake()
    {
        foreach (var item in Stars)
            item.GetComponent<Image>().color = Color.white;
    }

    public void Open(bool star1, bool star2, bool star3, int level)
    {
        LevelNumber = level;
        transform.name = level.ToString();
        name.GetComponent<Text>().text = name.GetComponent<Text>().text+" " + LevelNumber.ToString();
        if (star1)
            Stars[0].GetComponent<Image>().color = Color.green;
        if (star2)
            Stars[1].GetComponent<Image>().color = Color.green;
        if (star3)
            Stars[2].GetComponent<Image>().color = Color.green;
    }
    public void TaskOnClick()
    {
        Main.instance.TaskOnClick3();
        window = GameObject.FindGameObjectWithTag("Window");
        window.GetComponent<ComonWindow>().Close();
        Preloader.instance.Load(int.Parse(transform.name));
        Time.timeScale = 1;
        
    }
}
