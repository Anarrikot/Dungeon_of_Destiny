using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropItem : MonoBehaviour
{
    public float x, y, z;
    public void Start()
    {
        //gameObject.GetComponent<BoxCollider2D>().enabled=false;
    }
    public void active(Vector3 transform)
    {
        gameObject.transform.position=transform;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerInfo.inventory.New_Item(gameObject.GetComponent<Item>());
            Destroy(gameObject);
        }
    }
    public void Update()
    {
        
    }
}
