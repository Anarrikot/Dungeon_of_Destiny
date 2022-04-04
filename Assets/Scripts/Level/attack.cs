using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class attack : MonoBehaviour
{
    public int i;
    
    public List<GameObject> enemies;
    private GameObject enemy1;


    public bool isClicked;
    public Animator anim;
    public float TimeDelayMp;
    public float TimeDelayAttack;
    public Image MP;
    public Player player;
    

    private void Start()
    {
        PlayerInfo.damage = 20;
    }
    private void Update()
    {
        if (TimeDelayAttack <= PlayerInfo.TimeDelayAttack)
            TimeDelayAttack += Time.deltaTime;
        if (PlayerInfo.mp < 100)
        {
            TimeDelayMp += Time.deltaTime;
            if (TimeDelayMp >= PlayerInfo.TimeDelayMP)
            {
                PlayerInfo.mp++;
                TimeDelayMp = 0;
                MP.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, PlayerInfo.mp * 70 / 100);
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
        if (PlayerInfo.mp >= 20 && TimeDelayAttack >= PlayerInfo.TimeDelayAttack)
        {
            isClicked = true;
            anim.SetTrigger("Click");
            PlayerInfo.mp -= 20;
            MP.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, PlayerInfo.mp * 70 / 100);
        }
        if (isClicked && TimeDelayAttack >= PlayerInfo.TimeDelayAttack)
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
                enemies[i].GetComponent<Enemy>().TakeDamage(PlayerInfo.damage);
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
