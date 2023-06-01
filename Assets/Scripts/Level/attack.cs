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
                PlayerInfo.MP_Image.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, PlayerInfo.mp * 70 / 100);
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
       
        if (PlayerInfo.mp >= 20 && TimeDelayAttack >= PlayerInfo.TimeDelayAttack)
        {
            isClicked = true;
            PlayerInfo.mp -= 20;
            PlayerInfo.MP_Image.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, PlayerInfo.mp * 70 / 100);
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
                if(enemies[i].TryGetComponent<Enemy_Info>(out var _enemyInfo))
                {
                    _enemyInfo.TakeDamage(PlayerInfo.damage);
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
