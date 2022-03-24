using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsController 
{
    private GameObject myPrefab;
    public void OpenWindow(string name)
    {
        myPrefab = (GameObject)Resources.Load(name);
        Main.Instantiate(myPrefab, Main.instance.windowCanvas.transform);
    }


}
