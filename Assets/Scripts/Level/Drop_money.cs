using UnityEngine;

public class Drop_money : MonoBehaviour
{
    public float x, y, z;

    public void active(Vector3 transform)
    {
        gameObject.transform.position = transform;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerInfo.AddMoneyPlayer(10);
            Destroy(gameObject);
        }
    }
}
