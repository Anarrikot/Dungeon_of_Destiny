using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComonWindow : MonoBehaviour
{
    public void Start()
    {
        Time.timeScale = 0;
    }
    public void Close()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
    }
}
