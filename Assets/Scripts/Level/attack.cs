using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    public int i;
    
    public List<GameObject> enemies= new List<GameObject>();
    private GameObject enemy1;


    public bool isClicked;
    public Animator anim;
    public float TimeDelayMp;
    public float TimeDelayAttack;

    private void Update()
    {
        if (TimeDelayAttack <= PlayerInfo.khigth.TimeDelayAttack)
            TimeDelayAttack += Time.deltaTime;
        if (PlayerInfo.khigth.mp < PlayerInfo.khigth.mpMax)
        {
            TimeDelayMp += Time.deltaTime;
            if (TimeDelayMp >= PlayerInfo.khigth.TimeDelayMP)
            {
                PlayerInfo.khigth.mp++;
                TimeDelayMp = 0;
                PlayerInfo.MP_Image.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, PlayerInfo.khigth.mp * 70 / PlayerInfo.khigth.mpMax);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<Enemy_Info>().active();
            enemies.Add(collision.gameObject);
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<Enemy_Info>().active();
            enemies.Remove(collision.gameObject);
        }
    }
    public void TaskOnClick()
    {
       
        if (PlayerInfo.khigth.mp >= 20 && TimeDelayAttack >= PlayerInfo.khigth.TimeDelayAttack)
        {
            isClicked = true;
            PlayerInfo.khigth.mp -= 20;
            PlayerInfo.MP_Image.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, PlayerInfo.khigth.mp * 70 / PlayerInfo.khigth.mpMax);
        }
        if (isClicked && TimeDelayAttack >= PlayerInfo.khigth.TimeDelayAttack)
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
                if(enemies[i].TryGetComponent<Enemy_Info>(out var _enemyInfo))
                {
                    _enemyInfo.TakeDamage(PlayerInfo.khigth.damage);
                    if (_enemyInfo.lives <= 0)
                    {
                        enemy1 = enemies[i];
                        enemies.Remove(enemies[i]);
                        enemy1.GetComponent<Enemy_Info>().Drop();
                        Destroy(enemy1.gameObject);
                    }
                    else
                    {
                        i = i + 1;
                    }
                }
                
            }
        }
    }
}
