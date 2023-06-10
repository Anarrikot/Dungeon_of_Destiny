using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine.Networking;
using System;

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

public class MineData
{
    public InfoMine mine;
}

public class InfoMine
{
    public int uid;
    public DateTime time_money;
    public int lvl_money;
    public DateTime time_crystal;
    public int lvl_crystal;
}

public class GetInfo : MonoBehaviour
{

    private static GetInfo _instance;
    public static GetInfo Instance
        => _instance ??= new GetInfo();

    public GetInfo()
    {
        _instance = this;
    }

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
            Main.Instance.WindowController.AddWindow("NewPlayer");
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

    public async Task GetInfoMine(string url)
    {
        WWWForm form = new WWWForm();
        using var www = UnityWebRequestTexture.GetTexture(url);
        await Task.Yield();
        www.SetRequestHeader("Content-type", "aplication/json");
        var fff = www.SendWebRequest();
        while (!fff.isDone)
        {
            await Task.Yield();
        }
        MineData worldData = JsonConvert.DeserializeObject<MineData>(www.downloadHandler.text);

        Mine_script.lvl_money = worldData.mine.lvl_money;
        Mine_script.lvl_crystal = worldData.mine.lvl_crystal;
        Mine_script.time_money = worldData.mine.time_money;
        Mine_script.time_crystal = worldData.mine.time_crystal;
    }
}
