using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    string damage;
    //public float damage;
    public Player player;
    private void Start()
    {
        damage = this.gameObject.name;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            // enemy.accept_damage(player.damage);
           
            enemy.lives -=player.damage;
            if (enemy.lives <= 0)
            {
                Destroy(enemy.gameObject);
                enemy.CheckDrop();
            }
            //enemy.accept_damage(float.Parse(damage));  
        }
        this.gameObject.SetActive(false);
    }
}
