using UnityEngine;

public class Select_level : MonoBehaviour
{
    public GameObject window;
    public GameObject level;
    public bool Star1 = true;
    public bool Star2 = true;
    public bool Star3 = true;
    public bool active = true;



    public void Open_Window()
    {
        if(active)
        {
            level = Main.Instance.WindowController.OpenNow("SelectLevelWindow");
            level.GetComponent<SelectLevelWindow>().Open(Star1, Star2, Star3, int.Parse(transform.parent.name));
        }

    }
    public void Select()
    {
        Main.Instance.TaskOnClick3();
        window = GameObject.FindGameObjectWithTag("Window");
        window.GetComponent<ComonWindow>().Close();
        Preloader.Instance.Load(int.Parse(transform.parent.name));
        Time.timeScale = 1;
    }
}
