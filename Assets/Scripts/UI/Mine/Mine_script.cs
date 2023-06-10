using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine_script : MonoBehaviour
{
    private double collect;
    private int lvl_money = 1;
    private int reward_money = 60;
    private int lvl_crystal = 1;
    private int reward_crystal = 1;

    private DateTime TimeNow = DateTime.Now;


    public void Collect_Money()
    {
        DateTime time_money = DateTime.Now.AddSeconds(86400);
        double time = Convert.ToInt64((TimeNow - time_money).Ticks / 10000000);
        if (time < 86400)
            collect = Math.Floor(time / 60) * lvl_money * reward_money / 60;
        else
            collect = 24 * lvl_money * reward_money;
    }

    public void Collect_Crysatl()
    {
        DateTime time_crystal = DateTime.Now.AddSeconds(86400);
        double time = Convert.ToInt64((TimeNow - time_crystal).Ticks / 10000000);
        if (time < 86400)
            collect = Math.Floor(time / 60) * lvl_crystal * reward_crystal / 60;
        else
            collect = 24 * lvl_crystal * reward_crystal;
    }
}
