using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Camera camera;
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

    public void Update()
    {
        if (isClicked && TimeDelayAttack >= TimeDelay)
        {
            FindEnemy();
            isClicked = false;
            TimeDelayAttack = 0;
        }
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
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 tempVect = new Vector3(h, v, 0);
        tempVect = tempVect.normalized * speed * Time.deltaTime;
        rb.MovePosition(rb.transform.position + tempVect);
        if (h > 0)
            rb.transform.localScale = new Vector3(0.1f, 0.1f, 1f);
        else if (h < 0)
            rb.transform.localScale = new Vector3(-0.1f, 0.1f, 1f);

        if (Input.GetMouseButton(0))
        {
            Vector3 worldPos = camera.ScreenToWorldPoint(Input.mousePosition);

            Vector3 dir4 = new Vector3(worldPos.x - 0.6f, worldPos.y - 0.6f, 10);
            if (dir4.x - player.transform.position.x < 0 && dir4.y - player.transform.position.y < 3 && click)
            {
                if (active)
                {
                    i = worldPos.x;
                    k = worldPos.y;
                    controller.transform.position = new Vector3(i - 0.6f, k - 0.6f, 10);
                    i = i - camera.transform.position.x;
                    k = k - camera.transform.position.y;
                    active = false;
                    controller.active = true;
                }
            }
            else
            {
                click = false;
            }
            Vector3 dir3 = new Vector3(worldPos.x - camera.transform.position.x - i, worldPos.y - camera.transform.position.y - k, 0);
            if (active == false)
            {
                if (((Mathf.Pow(worldPos.x - i - camera.transform.position.x, 2) + Mathf.Pow(worldPos.y - k - camera.transform.position.y, 2)) <= 4))
                {
                    controller.transform.position = Vector3.MoveTowards(controller.transform.position, dir4, 20 * Time.deltaTime);
                }
                else
                {
                    x = worldPos.x - camera.transform.position.x - i;
                    y = worldPos.y - camera.transform.position.y - k;
                    x = 2 * x / Mathf.Sqrt(x * x + y * y);
                    if (worldPos.y - camera.transform.position.y > k)
                    {
                        y = Mathf.Sqrt(4 - x * x);
                    }
                    else
                    {
                        y = -Mathf.Sqrt(4 - x * x);
                    }
                    Vector3 dir5 = new Vector3(x - 0.6f + i + camera.transform.position.x, y - 0.6f + k + camera.transform.position.y, 10);
                    controller.transform.position = Vector3.MoveTowards(controller.transform.position, dir5, 300 * Time.deltaTime);
                }
                x = worldPos.x - camera.transform.position.x - i;
                y = worldPos.y - camera.transform.position.y - k;
                if (worldPos.x - camera.transform.position.x >= i)
                {
                    x = y / Mathf.Sqrt(x * x + y * y) * 283 / Mathf.PI;
                }
                else
                {
                    x = -y / Mathf.Sqrt(x * x + y * y) * 283 / Mathf.PI + 180;
                }
                coll.transform.rotation = Quaternion.Euler(0, 0, x);
                //player.transform.position = Vector3.MoveTowards(player.transform.position, player.transform.position + dir3, speed * Time.deltaTime);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            click = true;
            active = true;
            controller.active = false;
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
        camera = Camera.main;
        active = true;
        controller.active = false;
        click = true;

    }
}
