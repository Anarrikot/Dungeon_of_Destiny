using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class Preloader : MonoBehaviour
{
    public int uid;
    public Button m_Button;
    public Text m_text;
    public Canvas canvas;
    public GetInfo info;
   
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
        
    }
    public void Load()
    {
        LoadScene();
    }
    public async void LoadScene()
    {
        
        await GetInfo.instance.LaodfromServer("http://game.ispu.ru/game1/dod/api.php?api=getUser&uid=123123123");

        //while (GetInfo.instance.enabled==true)
        //{
        //    Debug.Log("fff");
        //    Task.Yield();           
        //}
        Main.instance.Show_HUD();
    }
}