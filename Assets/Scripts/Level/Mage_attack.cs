using System.Collections.Generic;
using UnityEngine;

public class Mage_attack : MonoBehaviour
{
    public List<GameObject> enemies=new List<GameObject>();
    private GameObject enemy1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemies.Add(collision.gameObject);
        }
    }

    public void Update()
    {
        if (enemies.Count > 0)
        {
            int i = 0;
            while (i < enemies.Count)
            {
                enemies[i].GetComponent<Enemy_Info>().TakeDamage(PlayerInfo.damage*50/100);
                if (enemies[i].GetComponent<Enemy_Info>().lives <= 0)
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
            Destroy(gameObject);
        }
    }
}
