using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using Newtonsoft.Json;
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
    public static bool verified;

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

        PlayerInfo.SetMoney(worldData.user.soft);
        PlayerInfo.SetCristals(worldData.user.hard);

        if (worldData.user.name == "New user")
        {
            Main.instance.WindowController.AddWindow("NewPlayer");
        }
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
