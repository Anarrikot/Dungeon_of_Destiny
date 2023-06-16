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
    }
    public class WorldData<T>
    {
        public List<T> lvl = new List<T>();
    }
    async void Awake()
    {
        active = true;
        await GetInfo.Instance.GetInfoLvl("http://game.ispu.ru/game1/dod/api.php?api=getLvl&uid=" + PlayerInfo.Instance.uid.ToString());
        int i = 1;
        foreach (Transform point in obj.transform)
        {
            if (i <= dataLvl.lvl.Count)
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
            else if (i == dataLvl.lvl.Count+1)
            {
                GameObject myPoint = point.GetComponent<GameObject>();
                myPoint = Instantiate(Resources.Load("Button") as GameObject, point.transform);
                myPoint.name = i+1.ToString();
                myPoint.GetComponentInChildren<Select_level>().active = true;
                myPoint.GetComponentInChildren<Select_level>().Star1 = false;
                myPoint.GetComponentInChildren<Select_level>().Star2 = false;
                myPoint.GetComponentInChildren<Select_level>().Star3 = false;
                points.Add(myPoint.transform.parent.gameObject);
            }
            i++;
        }
    }
    //public void Save()
    //{
    //    List<LevelInfo> levels = new List<LevelInfo>();
    //    int i =0;
    //    foreach (Transform point in obj.transform)
    //    {
    //        GameObject myPoint = point.GetComponent<GameObject>();
    //        myPoint = Instantiate(Resources.Load("Button") as GameObject, point.transform);
    //        points.Add(myPoint.transform.parent.gameObject);
    //        LevelInfo info = new LevelInfo()
    //        {
    //            level = myPoint.transform.parent.gameObject.name,
    //            star1 = true,
    //            star2 = true,
    //            star3 = true,
    //        };
    //        if (i>4)
    //        {
    //            info.star1 = false;
    //            info.star2 = false;
    //            info.star3 = false;
    //        }

    //        i++;

    //        levels.Add(info);
    //    }

    //    var data = new WorldData<LevelInfo>()
    //    {
    //        lvl = levels
    //    };
    //    File.WriteAllText(
    //        "Assets/Resources/map/map.json",
    //        JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
    //}
}
