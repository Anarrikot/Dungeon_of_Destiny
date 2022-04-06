using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 10;
    public int radius = 10;
    public Rigidbody2D rb;
    public GameObject enemy, HP;
    public float x, y;
    public bool collisionEnemy = false;
    public int lives = 60;
    public int damage = 5;
    public Player player;
    public float TimeDelay = 1;
    public float TimeDelayAttack;
    public GameObject[] dropList;
    public Animator animator;
    public bool target = false;

    public void Start()
    {
        animator = GetComponent<Animator>();
        HP.SetActive(false);
    }
    public void Update()
    {
        //HP.transform.localScale = new Vector3(lives * 0.3f / 60, HP.transform.localScale.y, HP.transform.localScale.z);

        if (IsFindEnemy() && !collisionEnemy)
        {
            if (!collisionEnemy)
                enemy.transform.position += (rb.transform.position - enemy.transform.position).normalized * speed * Time.deltaTime;
            if (enemy.transform.position.x - rb.position.x > 0)
                enemy.transform.localScale = new Vector3(0.3f, 0.3f, 1f);
            else if (enemy.transform.position.x - rb.position.x < 0)
                enemy.transform.localScale = new Vector3(-0.3f, 0.3f, 1f);
            if (animator)
                animator.SetBool("isRun", true);
        }


    }

    public bool IsFindEnemy()
    {
        x = Mathf.Abs(enemy.transform.position.x - rb.position.x);
        y = Mathf.Abs(enemy.transform.position.y - rb.position.y);
        if (Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2)) <= radius)
            return true;
        else
            return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collisionEnemy = true;
            if (animator)
                animator.SetBool("isRun", false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        rb.WakeUp();
        if (collision.gameObject.tag == "Player")
        {
            if (PlayerInfo.lives > 0)
            {
                TimeDelayAttack += Time.deltaTime;
                if (TimeDelayAttack >= TimeDelay)
                {
                    if (PlayerInfo.lives >= damage)
                        PlayerInfo.lives -= damage;
                    else
                        PlayerInfo.lives = 0;
                    TimeDelayAttack = 0;
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collisionEnemy = false;
        }
    }

    public void TakeDamage(int damage)
    {
        lives = lives - damage;
        HP.transform.localScale = new Vector3(lives * 0.3f / 60, HP.transform.localScale.y, HP.transform.localScale.z);
    }


    public void active()
    {
        if (target == true)
        {
            target = false;
            HP.SetActive(false);
        }
        else
        {
            target = true;
            HP.SetActive(true);
        }
    }
    //public void CheckDrop()
    //{ 
    //    int rnd = (int)Random.Range(0, 100);
    //    {
    //        if (rnd <= 50)
    //        {
    //            dropList[0].transform.position = gameObject.transform.position;
    //            Instantiate(dropList[0]);
    //        }
    //        else if (rnd > 50)
    //        {
    //            dropList[1].transform.position = gameObject.transform.position;
    //            Instantiate(dropList[1]);
    //        }
    //    }

    //}
}
