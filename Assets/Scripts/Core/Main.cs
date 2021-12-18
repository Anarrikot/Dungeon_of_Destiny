using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabNotification;


    public static Main instance = null;
    public AudioController Audio;
    public TranslateController Translate;
    public HudController Hud;
    public GameController Game;


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
}
