using System.Collections;
using System.Collections.Generic;
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
   
    // Start is called before the first frame update
    void Start()
    {
        //Load();
        if (start)
            StartCoroutine(LoadSceneWith());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    public void Load(int sceneID, bool FirstLoadScene)
    {
        StartCoroutine(LoadScene(sceneID, FirstLoadScene));
        //LoadScene(slider);
    }
    //public async void LoadScene(Slider bar)
    //{
    //    //AsyncOperation async = new AsyncOperation();
    //    GetInfo.instance.LaodfromServer("http://game.ispu.ru/game1/dod/api.php?api=getUser&uid=123123123",bar);

    //    //while (GetInfo.instance.enabled==true)
    //    //{
    //    //    Debug.Log("fff");
    //    //    Task.Yield();           
    //    //}
    //    Main.instance.Show_HUD();
    //}
    IEnumerator LoadScene(int sceneID ,bool FirstLoadScene)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneID);
        //AsyncOperation async1 = new AsyncOperation();
        //async1= GetInfo.instance.LaodfromServer("http://game.ispu.ru/game1/dod/api.php?api=getUser&uid=123123123",slider);
        async.allowSceneActivation = false;
        while (!async.isDone)
        {
            slider.value = async.progress;
            if (async.progress >= .9f && !async.allowSceneActivation)
            {
                Thread.Sleep(500);
                if (Input.GetMouseButtonDown(0))
                {
                    async.allowSceneActivation = true;
                }
            }
            yield return null;
        }

    }
    IEnumerator LoadSceneWith()
    {
        AsyncOperation async = new AsyncOperation();
        async = GetInfo.instance.LaodfromServer("http://game.ispu.ru/game1/dod/api.php?api=getUser&uid=123123123", slider);
        //async.allowSceneActivation = false;
        while (!async.isDone)
        {
            Debug.Log("fff");
            slider.value = async.progress;
            if (async.progress >= .9f && !async.allowSceneActivation)
            {
                Thread.Sleep(500);
                if (Input.GetMouseButtonDown(0))
                {
                    async.allowSceneActivation = true;
                    Destroy(gameObject);
                }
            }
            yield return null;
        }

    }
}