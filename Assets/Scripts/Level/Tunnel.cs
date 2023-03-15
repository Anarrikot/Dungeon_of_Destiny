using UnityEngine;

public class Tunnel : MonoBehaviour
{
    public GameObject exit;
    public GameObject player;
    public string type_exit;
    public void action()
    {
        Debug.Log(exit.GetComponent<Tunnel>().type_exit);
        switch (exit.GetComponent<Tunnel>().type_exit)
        {
            case "centre":
                player.gameObject.transform.position = exit.gameObject.transform.position;
                break;
            case "top":
                player.gameObject.transform.position = new Vector3(exit.gameObject.transform.position.x, exit.gameObject.transform.position.y + 1, exit.gameObject.transform.position.z);

                break;
            case "bottom":
                player.gameObject.transform.position = new Vector3(exit.gameObject.transform.position.x, exit.gameObject.transform.position.y - 1, exit.gameObject.transform.position.z);
                break;
            case "left":
                player.gameObject.transform.position = new Vector3(exit.gameObject.transform.position.x - 1, exit.gameObject.transform.position.y, exit.gameObject.transform.position.z);
                break;
            case "right":
                player.gameObject.transform.position = new Vector3(exit.gameObject.transform.position.x + 1, exit.gameObject.transform.position.y, exit.gameObject.transform.position.z);
                break;
        }
    }
}
