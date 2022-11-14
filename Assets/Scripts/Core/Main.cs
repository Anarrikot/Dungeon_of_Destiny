using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabNotification;
    private GameObject closeWindow;


    public static Main instance = null;
    public AudioController Audio;
    public TranslateController Translate;
    private HudController Hud;
    public Canvas windowCanvas;
    public Canvas HUD;
    public GameController Game;
    public WindowsController WindowController;
    //kkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk
    void Awake()
    {

        if (instance == null)
        {
            instance = this; // «адаем ссылку на экземпл€р объекта
        }
        else if (instance == this)
        {
            // Ёкземпл€р объекта уже существует на сцене
            Destroy(gameObject); // ”дал€ем объект
        }
        WindowController = new WindowsController();
        Hud = new HudController();
        WindowController.AddWindow("LoadScene");
    }
    public void Start_Load()
    {
    }
    // Start is called before the first frame update
    public void Start_HUD()
    {
        Hud.Show();
    }
    public void Show_HUD()
    {
        Hud.Show_HUD();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void TaskOnClick()
    {
        WindowController.AddWindow("Inventory");
    }
    public void TaskOnClick3()
    {
        WindowController.AddWindow("LoadScene");
    }
    public void Notification()
    {
        WindowController.AddWindow("Notification");
        WindowController.OpenNextWindow();  
    }
    public void Shop()
    {
        WindowController.AddWindow("Shop");
    }
    public void TaskOnClick1()
    {
        WindowController.AddWindow("Store");
    }

    public void TaskOnClick2()
    {
        WindowController.AddWindow("SelectGame");
    }
}
