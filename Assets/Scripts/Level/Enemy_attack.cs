using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy_attack : MonoBehaviour
{
    public GameObject enemy;
    public bool target = false;
    public bool collisionEnemy = false;
    public Enemy_Info info;
    // Start is called before the first frame update
    void Start()
    {
        info= enemy.GetComponent<Enemy_Info>();
    }

    // Update is called once per frame
    void Update()
    {
        if (info.attack_delay < info.attack_delay_time)
        {
            info.attack_delay += Time.deltaTime;
            if(info.attack_delay >= info.attack_delay_time)
            {
                info.attack_repeat = 0;
                attack();
                enemy.GetComponent<NavMeshAgent>().speed = 3.5f;
            }

        }
        if(info.attack_repeat < info.attack_repeat_time)
        {
            info.attack_repeat += Time.deltaTime;
        }
        if (info.attack_repeat >= info.attack_repeat_time && info.attack_delay >= info.attack_delay_time && collisionEnemy == true)
        {
                enemy.GetComponent<NavMeshAgent>().speed = 0;
            info.attack_delay = 0;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collisionEnemy = true;
            
        }
 
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collisionEnemy = false;
            if (info.animator)
                info.animator.SetBool("isRun", false);
        }
    }
    public void attack()
    {
        if(collisionEnemy==true)
        {
            if (PlayerInfo.lives > info.damage)
            {
                PlayerInfo.lives -= info.damage;
            }
            else
                PlayerInfo.lives = 0;
        }
    }
}
