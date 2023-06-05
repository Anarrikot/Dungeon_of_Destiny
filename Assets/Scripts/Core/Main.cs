using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabNotification;
    private GameObject closeWindow;





    public static Main Instance = null;
    public AudioController Audio;
    public TranslateController Translate;
    private HudController Hud;
    public Canvas windowCanvas;
    public Canvas HUD;
    public GameController Game;
    public WindowsController WindowController;

    void Awake()
    {

        if (Instance == null)
        {
            Instance = this; 
        }
        else if (Instance == this)
        {
            Destroy(gameObject); 
        }
        WindowController = new WindowsController();
        Hud = new HudController();
        WindowController.AddWindow("LoadScene");
        Player.Instance.Init();
    }

    public void Start_HUD()
    {
        Hud.Show();
    }
    public void Show_HUD()
    {
        Hud.Show_HUD();
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
