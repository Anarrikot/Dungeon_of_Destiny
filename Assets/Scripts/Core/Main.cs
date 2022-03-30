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
    public HudController Hud;
    public Canvas windowCanvas;
  
    public GameController Game;
    private WindowsController WindowController;
    //kkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk
    void Awake()
    {

        if (instance == null)
        {
            instance = this; // ������ ������ �� ��������� �������
        }
        else if (instance == this)
        {
            // ��������� ������� ��� ���������� �� �����
            Destroy(gameObject); // ������� ������
        }
        WindowController = new WindowsController();
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TaskOnClick()
    {
        WindowController.AddWindow("Inventory");
    }
}
