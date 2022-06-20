using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy_Info : MonoBehaviour
{
    public float attack_delay = 0.5f;
    public float attack_repeat = 2.0f;
    public float attack_delay_time = 0.5f;
    public float attack_repeat_time = 1f;
    public float TimeDelayShowHP = 0.7f;
    public int lives = 60;
    public int max_lives = 60;
    public int damage = 20;
    public GameObject HP;
    public bool target = false;
    public Animator animator;
    public float Chance=100f;
    public GameObject drop_item;
    public Die die;
    public delegate void Die(GameObject gameObj);
    void Awake()
    {
        animator = GetComponent<Animator>();
        HP.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeDelayShowHP <= 0.7f || target == true)
        {
            HP.SetActive(true);
            TimeDelayShowHP += Time.deltaTime;
        }
        else
        {
            HP.SetActive(false);
        }
    }
    public void TakeDamage(int damage)
    {
        TimeDelayShowHP = 0;
        lives = lives - damage;
        ShowHP();
    }
    public void ShowHP()
    {
        HP.transform.localScale = new Vector3(lives * 0.1f / 60, HP.transform.localScale.y, HP.transform.localScale.z);
    }
    public void Drop()
    {
        die(gameObject);
        int rand = Random.Range(0, 100);
        if (float.Parse(rand.ToString()) <= Chance)
        {
            GameObject new_item = Instantiate(drop_item, gameObject.transform.parent.transform);
            new_item.GetComponent<DropItem>().active(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y-0.5f, gameObject.transform.position.z));
        }
        
    }
    public void active()
    {
        if (target == true)
            target = false;
        else
            target = true;
    }
}
