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
            moneyText.text = (Math.Floor(time / 60) * lvl_money * reward_money / 60).ToString();
        else
            moneyText.text = (24 * lvl_money * reward_money).ToString();
        
        time = Convert.ToInt64((DateTime.Now - time_crystal).Ticks / 10000000);
        if (time < 86400)
            cristalText.text = (Math.Floor(time / 60) * lvl_crystal * reward_crystal / 60).ToString();
        else
            cristalText.text = (24 * lvl_crystal * reward_crystal).ToString();
    }

    public void Collect_Money()
    {
      
    }

    public void Collect_Crysatl()
    {
      
    }
}
