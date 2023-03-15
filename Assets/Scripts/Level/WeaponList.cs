using System.Collections.Generic;
using UnityEngine;
using System;

public class WeaponList : MonoBehaviour
{
    public static WeaponList instance;
    public TextAsset TextAssetData;
    public static List<Weapone> myWeaponeList = new List<Weapone>();
    Dictionary<string,int> specifications = new Dictionary<string,int>();
    private void Awake()
    {
        if (instance == null) instance = this;
        readCSV();
    }
    public static Weapone Foo(int i)
    {
        return myWeaponeList[0];
    }
    public void readCSV()
    {
        string[] data = TextAssetData.text.Split(new string[] {",","\n"}, StringSplitOptions.None);
        int tablesize = data.Length/4-1;
        for (int i = 1; i < tablesize+1; i++)
        {
            Weapone w = new Weapone();
            w.name = data[4*i];
            w.damage = int.Parse(data[4*i+1]);
            w.recharge = float.Parse(data[4 * i + 1]);
            w.PurchasePrice = int.Parse(data[4 * i + 1]);
            w.NextUpgradeCost = 0;
            myWeaponeList.Add(w);
            Debug.Log(myWeaponeList.Count);  
        }
    }
}


