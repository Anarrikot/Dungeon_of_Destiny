using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Camera myCamera;
    public Grid map;
    public GameObject player;
    private bool active, click;
    private float i, k, x, y, tg;
    public GameObject controller;
    public GameObject coll;

    public float speed = 10;
    public Rigidbody2D rb;
    public int lives = 100;
    public int mp = 100;
    public int damage = 25;
    public bool isClicked;
    public List<Enemy> enemys = new List<Enemy>();
    readonly List<Enemy> enemysToDestroy = new List<Enemy>();
    public Enemy thisEnemy;
    public bool death = false;
    public Animator anim;
    public Image HP, MP;
    public float TimeDelay = 0.5f;
    public float TimeDelay1 = 0.4f;
    public float TimeDelay2 = 0.2f;
    public float TimeDelayHp;
    public float TimeDelayMp;
    public float TimeDelayAttack;
    public Animator animator;

    public void Update()
    {
        HP.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, lives * 70 / 100);
        MP.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, mp * 70 / 100);
        if (lives <= 0)
            death = true;
        if (lives < 100 && !death)
        {
            TimeDelayHp += Time.deltaTime;
            if (TimeDelayHp >= TimeDelay1)
            {
                lives ++;
                TimeDelayHp = 0;
            }
        }
        if (mp < 100 && !death)
        {
            TimeDelayMp += Time.deltaTime;
            if (TimeDelayMp >= TimeDelay2)
            {
                mp ++;
                TimeDelayMp = 0;
            }
        }
        if (TimeDelayAttack <= TimeDelay)
            TimeDelayAttack += Time.deltaTime;
        else if (TimeDelayAttack/5 <= TimeDelay)
            coll.SetActive(false);
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 tempVect = new Vector3(h, v, 0);
        tempVect = tempVect.normalized * speed * Time.deltaTime;
        rb.MovePosition(rb.transform.position + tempVect);
        if (h > 0)
            rb.transform.localScale = new Vector3(0.1f, 0.1f, 1f);
        else if (h < 0)
            rb.transform.localScale = new Vector3(-0.1f, 0.1f, 1f);

        if (Input.GetMouseButton(0) && Time.timeScale != 0)
        {
            Vector3 worldPos = myCamera.ScreenToWorldPoint(Input.mousePosition);            
            Vector3 dir4 = new Vector3(worldPos.x , worldPos.y , 10);
            if (dir4.x - player.transform.position.x < 0 && dir4.y - player.transform.position.y < 3 && click)
                if (active)
                {
                    i = worldPos.x;
                    k = worldPos.y;
                    controller.transform.position = new Vector3(i, k, 10);
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
                    Vector3 dir5 = new Vector3(x  + i + myCamera.transform.position.x, y + k + myCamera.transform.position.y, 10);
                    controller.transform.position = Vector3.MoveTowards(controller.transform.position, dir5, 300 * Time.deltaTime);
                }
                
                x = worldPos.x - myCamera.transform.position.x - i;
                y = worldPos.y - myCamera.transform.position.y - k;
                if(x!=0 && y!=0)
                {
                    if (worldPos.x - myCamera.transform.position.x >= i)
                        x = y / Mathf.Sqrt(x * x + y * y) * 283 / Mathf.PI;
                    else
                        x = -y / Mathf.Sqrt(x * x + y * y) * 283 / Mathf.PI + 180;
                    coll.transform.rotation = Quaternion.Euler(0, 0, x);
                    
                }
                player.transform.position = Vector3.MoveTowards(player.transform.position, player.transform.position + dir3, speed / 2 * Time.deltaTime);
                if (worldPos.x - i - myCamera.transform.position.x < 0)
                    GetComponent<SpriteRenderer>().flipX=true;
                else if(worldPos.x - i - myCamera.transform.position.x > 0)
                    GetComponent<SpriteRenderer>().flipX = false;
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
    }

    public void TaskOnClick()
    {
        if (mp >= 20 && TimeDelayAttack >= TimeDelay)
        {
            isClicked = true;
            anim.SetTrigger("Click");
            mp -= 20;
        }
        if (isClicked && TimeDelayAttack >= TimeDelay)
        {
            coll.SetActive(true);
            isClicked = false;
            TimeDelayAttack = 0;
        }
        
    }

    public void Attack()
    {
        thisEnemy.lives -= damage;
        if (thisEnemy.lives <= 0)
            enemysToDestroy.Add(thisEnemy);
    }

    public void FindEnemy()
    {
        if (enemys.Count > 0)
            foreach (Enemy enemy in enemys)
            {
                if (Mathf.Sqrt(Mathf.Pow(Mathf.Abs(enemy.enemy.transform.position.x - rb.position.x), 2) + Mathf.Pow(Mathf.Abs(enemy.enemy.transform.position.y - rb.position.y), 2)) <= 2 && ((rb.transform.localScale.x > 0 && enemy.enemy.transform.position.x - rb.position.x > 0) || (rb.transform.localScale.x < 0 && enemy.enemy.transform.position.x - rb.position.x < 0)))
                {
                    thisEnemy = enemy;
                    Attack();
                }
            }
        foreach (Enemy enemy in enemysToDestroy)
            enemys.Remove(enemy);
        enemysToDestroy.Clear();
    }

    void Start()
    {
        myCamera = Camera.main;
        active = true;
        controller.SetActive(false);
        click = true;
        animator = GetComponent<Animator>();
    }
}
