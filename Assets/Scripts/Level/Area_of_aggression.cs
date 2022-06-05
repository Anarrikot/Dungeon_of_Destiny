using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area_of_aggression : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> enemies = new List<GameObject>();
    public bool start=true;
    void Start()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && !collision.GetComponent<AgentScript>().In_area)
        {
            collision.GetComponent<AgentScript>().In_area=true;
            enemies.Add(collision.gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            foreach (GameObject go in enemies)
            {
                go.GetComponent<AgentScript>().Set_active(collision.transform);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}