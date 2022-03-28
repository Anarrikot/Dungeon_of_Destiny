using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class attack : MonoBehaviour
{
    public int damage, i;
    public Player player;
    public List<GameObject> enemies;
    private GameObject enemy1;
    public int mp = 100;
    public Image MP;

    public bool isClicked;
    public Animator anim;
    public float TimeDelayMp;
    public float TimeDelay2 = 0.2f;
    public float TimeDelayAttack;
    public float TimeDelay = 0.5f;
    private void Start()
    {
        damage = 20;
    }
    private void Update()
    {
        if (TimeDelayAttack <= TimeDelay)
            TimeDelayAttack += Time.deltaTime;
        if (mp < 100)
        {
            TimeDelayMp += Time.deltaTime;
            if (TimeDelayMp >= TimeDelay2)
            {
                mp++;
                TimeDelayMp = 0;
                MP.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, mp * 70 / 100);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemies.Add(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemies.Remove(collision.gameObject);
        }
    }
    public void TaskOnClick()
    {
        if (mp >= 20 && TimeDelayAttack >= TimeDelay)
        {
            isClicked = true;
            anim.SetTrigger("Click");
            mp -= 20;
            MP.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, mp * 70 / 100);
        }
        if (isClicked && TimeDelayAttack >= TimeDelay)
        {
            hit();
            isClicked = false;
            TimeDelayAttack = 0;
        }
    }
    private void hit()
    {
        if (enemies.Count > 0)
        {
            i = 0;
            while (i < enemies.Count)
            {
                enemies[i].GetComponent<Enemy>().TakeDamage(damage);
                if (enemies[i].GetComponent<Enemy>().lives <= 0)
                {
                    enemy1 = enemies[i];
                    enemies.Remove(enemies[i]);
                    Destroy(enemy1.gameObject);
                    //enemy.GetComponent<Enemy>().CheckDrop();
                }
                else
                {
                    i = i + 1;
                }
            }
        }
    }
}
