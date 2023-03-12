using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class map_point_active : MonoBehaviour
{
    //public GameObject[] points;
    public List<GameObject> points = new List<GameObject>();
    public GameObject obj;
    private bool active;
    public class LevelInfo
    {
        public string name;
        public bool Star1 = new bool();
        public bool Star2 = new bool();
        public bool Star3 = new bool();
    }
    public class WorldData<T>
    {
        public List<T> user = new List<T>();
    }
    void Awake()
    {
        active = true;
        WorldData<LevelInfo> data = new WorldData<LevelInfo>();
        data = ReadJSON.instance.Load2<WorldData<LevelInfo>>("map/map");
        int i = 1;
        foreach (Transform point in obj.transform)
        {
            
            GameObject myPoint = point.GetComponent<GameObject>();
            myPoint = Instantiate(Resources.Load("Button") as GameObject, point.transform);
            myPoint.name = i.ToString();
            if (active)
            {
                myPoint.GetComponentInChildren<Select_level>().active = true;
                myPoint.GetComponentInChildren<Select_level>().Star1 = data.user[i - 1].Star1;
                //Debug.Log(myPoint.name + "   " + data.user[i - 1].Star1);
                myPoint.GetComponentInChildren<Select_level>().Star2 = data.user[i - 1].Star2;
                myPoint.GetComponentInChildren<Select_level>().Star3 = data.user[i - 1].Star3;
                Debug.Log(i + "   " + active+"   "+ myPoint.GetComponentInChildren<Select_level>().Star3);
                if (myPoint.GetComponentInChildren<Select_level>().Star1==false & myPoint.GetComponentInChildren<Select_level>().Star2 == false & myPoint.GetComponentInChildren<Select_level>().Star3==false)
                    active = false;
            }
            else
                myPoint.GetComponentInChildren<Select_level>().active = false;
            points.Add(myPoint.transform.parent.gameObject);
            i++;
        }
        //Save();






        //points = GameObject.FindGameObjectsWithTag("map_point");
        //foreach (GameObject point in points)
        //{
        //    GameObject myPoint = point;
        //    myPoint = Instantiate(Resources.Load("Button") as GameObject, point.transform);
        //}
    }
    public void Save()
    {
        List<LevelInfo> levels = new List<LevelInfo>();
        int i =0;
        foreach (Transform point in obj.transform)
        {
            GameObject myPoint = point.GetComponent<GameObject>();
            myPoint = Instantiate(Resources.Load("Button") as GameObject, point.transform);
            points.Add(myPoint.transform.parent.gameObject);
            LevelInfo info = new LevelInfo()
            {
                name = myPoint.transform.parent.gameObject.name,
                Star1 = true,
                Star2 = true,
                Star3 = true,
            };
            if (i>4)
            {
                info.Star1 = false;
                info.Star2 = false;
                info.Star3 = false;
            }

            i++;

            levels.Add(info);
        }




        var data = new WorldData<LevelInfo>()
        {
            user = levels
        };
        File.WriteAllText(
            "Assets/Resources/map/map.json",
            JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })

            );
    }
}
