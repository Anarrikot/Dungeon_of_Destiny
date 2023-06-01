using System.Collections;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private WindowsController WindowController;

    private void Awake()
    {
        WindowController = new WindowsController();
    }
    void Start()
    {
        StartCoroutine(DestroyObj());
    }

    IEnumerator DestroyObj()
    {
        yield return new WaitForSeconds(5.0f);
        PlayerInfo.Instance.lives = PlayerInfo.Instance.livesMax;
        WindowController.AddWindow("Lose");
        Destroy(gameObject);
    }
}
