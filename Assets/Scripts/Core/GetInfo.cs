using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using UnityEngine.Networking;

public class UserData
{
    public InfoP user;
}
public class InfoP
{
    public int uid;
    public string name;
    public int soft;
    public int hard; 
}

public class GetInfo : MonoBehaviour
{
    public static GetInfo instance;
    //public static InfoP output;
    public void Set_dun_user()
    {
       StartCoroutine( LaodfromServer("http://game.ispu.ru/game1/dod/api.php?api=getUser&uid=123123123"));
    }
    IEnumerator LaodfromServer(string url)
    {
        WWWForm form = new WWWForm();
        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();
            UserData worldData = JsonConvert.DeserializeObject<UserData>(www.downloadHandler.text);
            PlayerInfo.name = worldData.user.name;
            PlayerInfo.uid = worldData.user.uid;
            PlayerInfo.SetMoney(worldData.user.soft);
            PlayerInfo.SetCristals(worldData.user.hard);
        }
    }
    private void Awake()
    {
        if (instance == null) instance = this;
    }
}
