using System.Collections;
using System.Collections.Generic;
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
        PlayerInfo.lives = PlayerInfo.livesMax;
        WindowController.AddWindow("Lose");
        Destroy(gameObject);
    }
}
