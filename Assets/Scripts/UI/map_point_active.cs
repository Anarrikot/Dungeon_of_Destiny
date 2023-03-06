using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map_point_active : MonoBehaviour
{
    public GameObject[] points;
    void Awake()
    {
        points = GameObject.FindGameObjectsWithTag("map_point");
        foreach (GameObject point in points)
        {
            GameObject myPoint = point;
            myPoint = Instantiate(Resources.Load("Button") as GameObject, point.transform);
        }
    }
}
