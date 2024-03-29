using System.Collections.Generic;
using UnityEngine;

public class Сlosest_enemy : MonoBehaviour
{
    public int i;

    public List<GameObject> enemies=new List<GameObject>();
    private GameObject enemy;

    public bool isClicked;
    public Animator anim;
    public float TimeDelayMp;
    public float TimeDelayAttack;
    public GameObject splash,splash1;
    public ClassInfo thisClass;


    public void Start()
    {
        thisClass = Player.Instance.thisClass;   
    }
        private void Update()
    {
        if (TimeDelayAttack <= thisClass.TimeDelayAttack)
            TimeDelayAttack += Time.deltaTime;
        if (thisClass.mp < thisClass.mpMax)
        {
            TimeDelayMp += Time.deltaTime;
            if (TimeDelayMp >= thisClass.TimeDelayMP)
            {
                thisClass.mp++;
                TimeDelayMp = 0;
                PlayerInfo.MP_Image.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, thisClass.mp * 70 / thisClass.mpMax);
            }
        }
        if(enemies.Count > 0)
        {
            foreach (GameObject enemy in enemies)
            {
                if(this.enemy!= null && this.enemy!=enemy)
                {
                    float distance = Vector2.Distance(Player.Instance.transform.position, enemy.transform.position);
                    if(distance < Vector2.Distance(Player.Instance.transform.position, this.enemy.transform.position))
                    {
                        this.enemy.GetComponent<Enemy_Info>().target =true;
                        enemy.GetComponent<Enemy_Info>().target=false;
                        this.enemy = enemy;
                    }
                }
                else if(this.enemy != enemy)
                {
                    enemy.GetComponent<Enemy_Info>().target=true;
                    this.enemy = enemy;
                }
            }
        }

        else if(enemy != null)
        {
            enemy.GetComponent<Enemy_Info>().target=false;
            enemy = null;
        }
        
    }
    public void OnDestroy()
    {
        if (enemy != null)
        {
            enemy.GetComponent<Enemy_Info>().active();
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

        if (thisClass.mp >= 20 && TimeDelayAttack >= thisClass.TimeDelayAttack && enemy!=null)
        {

            isClicked = true;
            thisClass.mp -= 20;
            PlayerInfo.MP_Image.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, thisClass.mp * 70 / thisClass.mpMax);
        }
        if (isClicked && TimeDelayAttack >= thisClass.TimeDelayAttack)
        {

            hit();
            isClicked = false;
            TimeDelayAttack = 0;
        }
    }
    private void hit()
    {

        splash1 = GameObject.Instantiate(splash);
        if(PlayerInfo.classes[PlayerInfo.Instance.this_classes]=="Mage")
        {
            enemy.GetComponent<Enemy_Info>().TakeDamage(thisClass.damage * 50 / 100);
            splash1.transform.position = enemy.transform.position;
        }

        if (PlayerInfo.classes[PlayerInfo.Instance.this_classes] == "Archer")
        {
            splash1.transform.position = gameObject.transform.position;
            splash1.GetComponent<Arrow>().add_cord(enemy.transform.position.x-gameObject.transform.position.x, enemy.transform.position.y - gameObject.transform.position.y);
        }
    }
}
