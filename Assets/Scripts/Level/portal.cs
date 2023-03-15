using System.Collections;
using UnityEngine;

public class portal : MonoBehaviour
{
    public GameObject gameObj;
    private WindowsController WindowController;
    private IEnumerator coroutine;

    private void Awake()
    {
        WindowController = new WindowsController();
        coroutine = Win();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObj.SetActive(true);
            StartCoroutine(coroutine);
        }
    }

    IEnumerator Win()
    {
        yield return new WaitForSeconds(3.0f);
        PlayerInfo.lives = PlayerInfo.livesMax;
        ReadJSON.instance.SaveInfo();
        ReadJSON.instance.SaveInvenory();
        WindowController.AddWindow("Win");
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObj.SetActive(false);
            StopCoroutine(coroutine);
        }
    }
}
