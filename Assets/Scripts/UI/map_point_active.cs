using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using UnityEngine.UI;
using System.Drawing;

public class map_point_active : MonoBehaviour
{
    public List<GameObject> points = new List<GameObject>();
    public GameObject obj;
    private bool active;
    public static WorldData<LevelInfo> dataLvl = new WorldData<LevelInfo>();
    public class LevelInfo
    {
        public int uid;
        public string level;
        public string star1;
        public string star2;
        public string star3;

        public LevelInfo(int uid, string level, string star1, string star2, string star3)
        {
            this.uid = uid;
            this.level = level;
            this.star1 = star1;
            this.star2 = star2;
            this.star3 = star3;
        }
    }
    public class WorldData<T>
    {
        public List<T> lvl = new List<T>();
    }
    async void Awake()
    {
        active = true;
        await GetInfo.Instance.GetInfoLvl("http://game.ispu.ru/game1/dod/api.php?api=getLvl&uid=" + PlayerInfo.uid.ToString());
        int i = 1;
        foreach (Transform point in obj.transform)
        {
            if (dataLvl.lvl[0].star1 == "0")
            {
                GameObject myPoint = point.GetComponent<GameObject>();
                myPoint = Instantiate(Resources.Load("Button") as GameObject, point.transform);
                myPoint.name = dataLvl.lvl[i - 1].level;
                myPoint.GetComponentInChildren<Select_level>().Star1 = dataLvl.lvl[i - 1].star1 == "1";
                myPoint.GetComponentInChildren<Select_level>().Star2 = dataLvl.lvl[i - 1].star2 == "1";
                myPoint.GetComponentInChildren<Select_level>().Star3 = dataLvl.lvl[i - 1].star3 == "1";
                points.Add(myPoint.transform.parent.gameObject);
                break;
            }
            else if (i <= dataLvl.lvl.Count)
            {
                GameObject myPoint = point.GetComponent<GameObject>();
                myPoint = Instantiate(Resources.Load("Button") as GameObject, point.transform);
                myPoint.name = dataLvl.lvl[i - 1].level;
                if (active)
                {
                    myPoint.GetComponentInChildren<Select_level>().active = true;
                    myPoint.GetComponent<Image>().color = UnityEngine.Color.green;

                    myPoint.GetComponentInChildren<Select_level>().Star1 = dataLvl.lvl[i - 1].star1 == "1";
                    myPoint.GetComponentInChildren<Select_level>().Star2 = dataLvl.lvl[i - 1].star2 == "1";
                    myPoint.GetComponentInChildren<Select_level>().Star3 = dataLvl.lvl[i - 1].star3 == "1";
                    if (myPoint.GetComponentInChildren<Select_level>().Star1 == false & myPoint.GetComponentInChildren<Select_level>().Star2 == false & myPoint.GetComponentInChildren<Select_level>().Star3 == false)
                        active = false;
                }
                else
                    myPoint.GetComponentInChildren<Select_level>().active = false;
                points.Add(myPoint.transform.parent.gameObject);
            }
            else if (i == dataLvl.lvl.Count + 1)
            {
                GameObject myPoint = point.GetComponent<GameObject>();
                myPoint = Instantiate(Resources.Load("Button") as GameObject, point.transform);
                myPoint.name = i + 1.ToString();
                myPoint.GetComponentInChildren<Select_level>().active = true;
                myPoint.GetComponentInChildren<Select_level>().Star1 = false;
                myPoint.GetComponentInChildren<Select_level>().Star2 = false;
                myPoint.GetComponentInChildren<Select_level>().Star3 = false;
                points.Add(myPoint.transform.parent.gameObject);
                dataLvl.lvl.Add(new LevelInfo(PlayerInfo.uid, (i - 1).ToString(), "0", "0", "0"));
                break;
            }
            i++;
        }
    }
}
