using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // Start is called before the first frame update
    void Start()
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
    public void active()
    {
        if (target == true)
            target = false;
        else
            target = true;
    }
}