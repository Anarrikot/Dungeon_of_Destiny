using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;



public class GetInfo : MonoBehaviour
{
    public static GetInfo instance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void fff()
    {
       StartCoroutine( LaodfromServer("http://game.ispu.ru/game1/dod/api.php?api=getUser&uid=123123123"));

    }
    IEnumerator LaodfromServer(string url)
    {
        var request =  UnityWebRequest.Get(url) ;
        yield return request.SendWebRequest();
        Debug.Log(request.downloadHandler.text);
        var text = request.downloadHandler.text;
        ReadJSON.instance.fff(text);
        
    }
    private void Awake()
    {
        if (instance == null) instance = this;
    }
}
