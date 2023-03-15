using UnityEngine;
using UnityEngine.UI;

public class NewPlayer : MonoBehaviour
{
    public Text name;
    public void TaskOnClick()
    {
        GetInfo.instance.SetForServer("http://game.ispu.ru/game1/dod/api.php?api=changeName&uid=" + PlayerInfo.uid.ToString() + "&name=" + name.text);
        gameObject.GetComponent<ComonWindow>().Close();
    }
}
