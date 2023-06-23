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
    
    public static GameObject square;
    public static Animator animator;
    public float TimeDelayHp;
    public GameObject drop_item, deathPerfab, death_anim;
    public Vector3 start_position, target_position;
    public ClassInfo thisClass;
    [SerializeField] public static NavMeshAgent agent;






    private static Player _instance;
    public static Player Instance
        => _instance ??= new Player();

    public Player()
    {
        _instance = this;
    }

    public static void New_skin(GameObject square1)
    {
        square = square1;
        animator = square.GetComponent<Animator>();
    }
    public void Start()
    {
        
        controller.SetActive(false);
        animator = square.GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateUpAxis = false;
        agent.updateRotation = false;
    }
    public void Init()
    {
        PlayerInfo.button_atc = button;
        myCamera = Camera.main;
        active = true;
        click = true;
        square = square1;
        thisClass = PlayerInfo.khigth;
    }
    public void Update()
    {
        PlayerInfo.HP_Image.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, thisClass.lives * 70 / thisClass.livesMax);
        if (thisClass.lives == 0)
        {
            Instantiate(death_anim, transform.position, Quaternion.identity);
            death = true;
            deathPerfab = Main.Instantiate(deathPerfab, Main.Instance.windowCanvas.transform);
            thisClass.lives = -1;
        }

        if (thisClass.lives < thisClass.livesMax && !death)
        {
            TimeDelayHp += Time.deltaTime;
            if (TimeDelayHp >= thisClass.TimeDelayHP)
            {
                thisClass.lives ++;
                TimeDelayHp = 0;
            }
        }
    }
}
