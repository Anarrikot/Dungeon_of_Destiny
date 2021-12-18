using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransformPlayer : MonoBehaviour
{

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
}
