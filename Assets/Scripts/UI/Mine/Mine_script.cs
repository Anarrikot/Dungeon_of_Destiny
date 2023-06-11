using System;
using UnityEngine;
using UnityEngine.UI;

public class Mine_script : MonoBehaviour
{
    private double collect;
    public static int lvl_money;
    private int reward_money = 60;
    public static int lvl_crystal;
    private int reward_crystal = 1;
    public static DateTime time_crystal;
    public static DateTime time_money;

    public Text moneyText;
    public Text cristalText;


    public async void Start()
    {
        await GetInfo.Instance.GetInfoMine("http://game.ispu.ru/game1/dod/api.php?api=getInfoMine&uid=" + PlayerInfo.Instance.uid.ToString());
        
        double time = Convert.ToInt64((DateTime.Now - time_money).Ticks / 10000000);
        if (time < 86400)
            moneyText.text = (Math.Floor(time / 60 * lvl_money * reward_money / 60)).ToString();
        else
            moneyText.text = (24 * lvl_money * reward_money).ToString();
        
        time = Convert.ToInt64((DateTime.Now - time_crystal).Ticks / 10000000);
        if (time < 86400)
            cristalText.text = (Math.Floor(time / 60 * lvl_crystal * reward_crystal / 60)).ToString();
        else
            cristalText.text = (24 * lvl_crystal * reward_crystal).ToString();
    }

    public async void Collect_Money()
    {
        PlayerInfo.AddMoneyPlayer(int.Parse(moneyText.text));
        moneyText.text = "0";
        await GetInfo.Instance.SetInfoForServer("http://game.ispu.ru/game1/dod/api.php?api=userUpdateInfo&uid=" + PlayerInfo.Instance.uid.ToString() + "&soft=" + PlayerInfo.Instance.money.ToString() + "&hard=" + PlayerInfo.Instance.cristals.ToString());
        await GetInfo.Instance.SetInfoForServer("http://game.ispu.ru/game1/dod/api.php?api=collectMine&uid=" + PlayerInfo.Instance.uid.ToString() + "&type=money");
    }

    public async void Collect_Crysatl()
    {
        PlayerInfo.AddCristalPlayer(int.Parse(cristalText.text));
        cristalText.text = "0";
        await GetInfo.Instance.SetInfoForServer("http://game.ispu.ru/game1/dod/api.php?api=userUpdateInfo&uid=" + PlayerInfo.Instance.uid.ToString() + "&soft=" + PlayerInfo.Instance.money.ToString() + "&hard=" + PlayerInfo.Instance.cristals.ToString());
        await GetInfo.Instance.SetInfoForServer("http://game.ispu.ru/game1/dod/api.php?api=collectMine&uid=" + PlayerInfo.Instance.uid.ToString() + "&type=crystal");
    }
}
