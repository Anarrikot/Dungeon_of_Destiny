using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System.Threading;

public class Preloader : MonoBehaviour
{
    public static Preloader instance;
    public int uid;
    public Button m_Button;
    public Text m_text;
    public Canvas canvas;
    public GetInfo info;
    public Slider slider;
    public bool start=false;
   
    void Start()
    {
            LoadSceneWith();
    }
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    public void Load(int sceneID)
    {
        StartCoroutine(LoadScene(sceneID));
    }
    IEnumerator LoadScene(int sceneID)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneID);
        async.allowSceneActivation = false;
        while (!async.isDone)
        {
            slider.value = async.progress;
            if (async.progress >= .9f && !async.allowSceneActivation)
            {
                Thread.Sleep(500);
                async.allowSceneActivation = true;
            }
            yield return null;
        }

    }
    public async void LoadSceneWith()
    {
        Main.instance.Start_HUD();
        PlayerInfo.Start_Set();
        AsyncOperation async = new AsyncOperation();
        await Task.Delay(1000);
        await GetInfo.instance.LaodfromServer("http://game.ispu.ru/game1/dod/api.php?api=getUser&uid=" + PlayerInfo.uid.ToString(), slider);
        await Task.Delay(3000);
        if (this != null)
            gameObject.GetComponent<ComonWindow>().Close();
    }
}