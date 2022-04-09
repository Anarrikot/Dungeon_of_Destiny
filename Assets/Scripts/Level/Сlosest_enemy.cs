using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Сlosest_enemy : MonoBehaviour
{
    public int i;

    public List<GameObject> enemies=new List<GameObject>();
    private GameObject enemy;

    public bool isClicked;
    public Animator anim;
    public float TimeDelayMp;
    public float TimeDelayAttack;
    //public Image MP;
   // public Player player;
    public GameObject splash,splash1;
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
        if(enemies.Count > 0)
        {
            foreach (GameObject enemy in enemies)
            {
                if(this.enemy!= null && this.enemy!=enemy)
                {
                    float distance = Vector2.Distance(Player.instance.transform.position, enemy.transform.position);
                    if(distance < Vector2.Distance(Player.instance.transform.position, this.enemy.transform.position))
                    {
                        this.enemy.GetComponent<Enemy>().active();
                        enemy.GetComponent<Enemy>().active();
                        this.enemy = enemy;
                    }
                }
                else if(this.enemy != enemy)
                {
                    enemy.GetComponent<Enemy>().active();
                    this.enemy = enemy;
                }
            }
        }
        else if(enemy != null)
        {
            enemy.GetComponent<Enemy>().active();
            enemy = null;
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
        if (PlayerInfo.mp >= 20 && TimeDelayAttack >= PlayerInfo.TimeDelayAttack && enemy!=null)
        {
            isClicked = true;
            //anim.SetTrigger("Click");
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
        enemy.GetComponent<Enemy>().TakeDamage(PlayerInfo.damage * 50 / 100);
        splash1 = Instantiate(splash);
        splash1.transform.position=enemy.transform.position;     
    }
}
