using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select_level : MonoBehaviour
{
    public GameObject window;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Select()
    {
        Main.instance.TaskOnClick3();
        window = GameObject.FindGameObjectWithTag("Window");
        window.GetComponent<ComonWindow>().Close();
        Preloader.instance.Load(1);
        Time.timeScale = 1;
    }
}
