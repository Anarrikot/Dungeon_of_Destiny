using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        PlayerInfo.Instance.lives = PlayerInfo.Instance.livesMax;
        ReadJSON.Instance.SaveInfo();
        ReadJSON.Instance.SaveInvenory();
        GetInfo.Instance.SetForServer("http://game.ispu.ru/game1/dod/api.php?api=lvlSaveInfo&uid=" + PlayerInfo.Instance.uid.ToString() + "&level=" + SceneManager.GetActiveScene().buildIndex.ToString() + "&star1=1");
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
