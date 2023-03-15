using UnityEngine;

public class DropItem : MonoBehaviour
{
    public float x, y, z;
  
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
}
