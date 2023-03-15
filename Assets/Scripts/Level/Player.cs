using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Camera myCamera;
    public Grid map;
    private bool active, click;
    private float i, k, x, y, tg;
    public GameObject controller;
    public GameObject coll;
    public Rigidbody2D rb;
    public Button button;
    public GameObject square1;
    public bool death = false;
    public static Player instance;
    public static GameObject square;
    public static Animator animator;
    public float TimeDelayHp;
    public GameObject drop_item, deathPerfab;
    public Vector3 start_position, target_position;
    [SerializeField] public static NavMeshAgent agent;
    public static void New_skin(GameObject square1)
    {
        square = square1;
        animator = square.GetComponent<Animator>();
    }
    public void Start()
    {
        Main.instance.Show_HUD();
    }
    public void Awake()
    {
        if (instance == null) instance = this;
        PlayerInfo.button_atc = button;
        myCamera = Camera.main;
        active = true;
        controller.SetActive(false);
        click = true;
        square = square1;
        animator = square.GetComponent<Animator>();
        Main.instance.Show_HUD();

        agent = GetComponent<NavMeshAgent>();
        agent.updateUpAxis = false;
        agent.updateRotation = false;
    }
    public void Update()
    {
        PlayerInfo.HP_Image.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, PlayerInfo.lives * 70 / 100);
        if (PlayerInfo.lives == 0)
        {
            death = true;
            deathPerfab = Main.Instantiate(deathPerfab, Main.instance.windowCanvas.transform);
            PlayerInfo.lives = -1;
        }

        if (PlayerInfo.lives < 100 && !death)
        {
            TimeDelayHp += Time.deltaTime;
            if (TimeDelayHp >= PlayerInfo.TimeDelayHP)
            {
                PlayerInfo.lives ++;
                TimeDelayHp = 0;
            }
        }
    }
}
