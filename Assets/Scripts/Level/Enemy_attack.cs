using UnityEngine;
using UnityEngine.AI;

public class Enemy_attack : MonoBehaviour
{
    public GameObject enemy;
    public bool target = false;
    public bool collisionEnemy = false;
    public Enemy_Info info;
    private NavMeshAgent _navmeshAgent;

    void Start()
    {
        info= enemy.GetComponent<Enemy_Info>();
        _navmeshAgent = enemy.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (info.attack_delay < info.attack_delay_time)
        {
            info.attack_delay += Time.deltaTime;
            if(info.attack_delay >= info.attack_delay_time)
            {
                info.attack_repeat = 0;
                attack();
                _navmeshAgent.speed = 3.5f;
            }

        }
        if(info.attack_repeat < info.attack_repeat_time)
        {
            info.attack_repeat += Time.deltaTime;
        }
        if (info.attack_repeat >= info.attack_repeat_time && info.attack_delay >= info.attack_delay_time && collisionEnemy == true)
        {
            _navmeshAgent.speed = 0;
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
        if(collisionEnemy==true && PlayerInfo.Instance.lives > 0)
        {
            if (PlayerInfo.Instance.lives > info.damage)
            {
                PlayerInfo.Instance.lives -= info.damage;
            }
            else
                PlayerInfo.Instance.lives = 0;
        }
    }
}
