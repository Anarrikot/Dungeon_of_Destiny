using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using UnityEngine.Networking;
using System.Threading;

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
    public static bool verified;
    //public static InfoP output;
    public AsyncOperation Set_dun_user(string url)
    {
        //AsyncOperation async= StartCoroutine(Laodfrom("http://game.ispu.ru/game1/dod/api.php?api=getUser&uid=123123123"));
        //LaodfromServer("http://game.ispu.ru/game1/dod/api.php?api=getUser&uid=123123123");
        return null;
    }
    public async Task LaodfromServer(string url,Slider bar)
    {
        WWWForm form = new WWWForm();
        using var www = UnityWebRequestTexture.GetTexture(url);
        await Task.Yield();
        www.SetRequestHeader("Content-type","aplication/json");
        var fff = www.SendWebRequest();
        

        while(!fff.isDone)
        {
            
            await Task.Yield();
            bar.value = fff.progress;

        }
            
        UserData worldData = JsonConvert.DeserializeObject<UserData>(www.downloadHandler.text);
        Debug.Log(www.downloadHandler.text);

        PlayerInfo.SetMoney(worldData.user.soft);
        PlayerInfo.SetCristals(worldData.user.hard);

        if (worldData.user.name == "New user")
        {
            Main.instance.WindowController.AddWindow("NewPlayer");
        }
        // }



    }

    public async Task SetForServer(string url)
    {
        WWWForm form = new WWWForm();
        using var www = UnityWebRequestTexture.GetTexture(url);
        await Task.Yield();
        www.SetRequestHeader("Content-type", "aplication/json");
        var fff = www.SendWebRequest();
        while (!fff.isDone)
            await Task.Yield();
    }
    IEnumerator Laodfrom(string url)
    {
        WWWForm form = new WWWForm();
        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();
            UserData worldData = JsonConvert.DeserializeObject<UserData>(www.downloadHandler.text);
            Debug.Log(worldData.user.name);
            //PlayerInfo.name = worldData.user.name;
            //PlayerInfo.uid = worldData.user.uid;
            //PlayerInfo.SetMoney(worldData.user.soft);
            //PlayerInfo.SetCristals(worldData.user.hard);
        }
        
    }

    public async Task ReturnInfo(string Name, int money)
    {
        WWWForm form = new WWWForm();
        using var www = UnityWebRequestTexture.GetTexture(Name);
        await Task.Yield();
        www.SetRequestHeader("Content-type", "aplication/json");
        var fff = www.SendWebRequest();
        while (!fff.isDone)
            await Task.Yield();
        UserData worldData = JsonConvert.DeserializeObject<UserData>(www.downloadHandler.text);
        
        if (worldData.user.soft >= money)
            verified = true;

    }

    private void Awake()
    {
        if (instance == null) instance = this;
    }
}
