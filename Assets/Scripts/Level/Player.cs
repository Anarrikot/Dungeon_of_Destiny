using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Camera myCamera;
    public Grid map;
    //public GameObject player;
    private bool active, click;
    private float i, k, x, y, tg;
    public GameObject controller;
    public GameObject coll;
    //public Image HP;
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
    }
    //public int lives = 100;
    //public float speed = 10;
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

        /*
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 tempVect = new Vector3(h, v, 0);
        tempVect = tempVect.normalized * PlayerInfo.speed * Time.deltaTime;
        rb.MovePosition(rb.transform.position + tempVect);
        if (h > 0)
            rb.transform.localScale = new Vector3(0.1f, 0.1f, 1f);
        else if (h < 0)
            rb.transform.localScale = new Vector3(-0.1f, 0.1f, 1f);

        if (Input.GetMouseButton(0) && Time.timeScale != 0 && !death)
        {
            Vector3 worldPos = myCamera.ScreenToWorldPoint(Input.mousePosition);            
            Vector3 dir4 = new Vector3(worldPos.x , worldPos.y , -10);
            if (dir4.x - instance.transform.position.x < 0 && dir4.y - instance.transform.position.y < 3 && click)
                if (active)
                {
                    
                    i = worldPos.x;
                    k = worldPos.y;
                    controller.transform.position = new Vector3(i, k, -10);
                    i = i - myCamera.transform.position.x;
                    k = k - myCamera.transform.position.y;
                    active = false;
                    controller.SetActive(true);
                    if (animator)
                        animator.SetBool("isRun", true);
                }
            else
                click = false;
            
            Vector3 dir3 = new Vector3(worldPos.x - myCamera.transform.position.x - i, worldPos.y - myCamera.transform.position.y - k, 0);
            if (active == false)
            {
                if (((Mathf.Pow(worldPos.x - i - myCamera.transform.position.x, 2) + Mathf.Pow(worldPos.y - k - myCamera.transform.position.y, 2)) <= 4))
                    controller.transform.position = Vector3.MoveTowards(controller.transform.position, dir4, 20 * Time.deltaTime);
                else
                {
                    x = worldPos.x - myCamera.transform.position.x - i;
                    y = worldPos.y - myCamera.transform.position.y - k;
                    x = 2 * x / Mathf.Sqrt(x * x + y * y);
                    if (worldPos.y - myCamera.transform.position.y > k)
                        y = Mathf.Sqrt(4 - x * x);
                    else
                        y = -Mathf.Sqrt(4 - x * x);
                    Vector3 dir5 = new Vector3(x  + i + myCamera.transform.position.x, y + k + myCamera.transform.position.y, -10);
                    controller.transform.position = Vector3.MoveTowards(controller.transform.position, dir5, 300 * Time.deltaTime);
                }
                
                x = worldPos.x - myCamera.transform.position.x - i;
                y = worldPos.y - myCamera.transform.position.y - k;
                PlayerInfo.x = x;
                PlayerInfo.y = y;   
                if(x!=0 && y!=0)
                {
                    if (worldPos.x - myCamera.transform.position.x >= i)
                        x = y / Mathf.Sqrt(x * x + y * y) * 283 / Mathf.PI;
                    else
                        x = -y / Mathf.Sqrt(x * x + y * y) * 283 / Mathf.PI + 180;
                    coll.transform.rotation = Quaternion.Euler(0, 0, x);
                    
                }
                instance.transform.position = Vector3.MoveTowards(instance.transform.position, instance.transform.position + dir3, PlayerInfo.speed / 2 * Time.deltaTime);
                if (worldPos.x - i - myCamera.transform.position.x < 0)
                   square.GetComponent<SpriteRenderer>().flipX=true;
                else if(worldPos.x - i - myCamera.transform.position.x > 0)
                   square.GetComponent<SpriteRenderer>().flipX = false;
            }
            
        }

        if (Input.GetMouseButtonUp(0))
        {
            click = true;
            active = true;
            controller.SetActive(false);
            if (animator)
                animator.SetBool("isRun", false);
        }
        */
        //agent.destination = new Vector3(gameObject.transform.position.x-1, gameObject.transform.position.y);
    }
}
