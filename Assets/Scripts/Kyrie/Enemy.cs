using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public int xpPoints;
    protected Animator anim;

    public GameObject Canvas;
    public GameObject image;
    public float CurrentHealth;
    public Image imageFill;

    public bool canDie = true;
    private void OnEnable()
    {
        GameEvents.DamageEnemy += TakeDamage;
    }
    private void OnDisable()
    {
        GameEvents.DamageEnemy -= TakeDamage;
    }

    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
        health = maxHealth;
        CalculateHealth();
        if (imageFill != null) imageFill.fillAmount = CurrentHealth;

    }

    protected virtual void TakeDamage(int damage, GameObject target)
    {
        if (gameObject == target)
        {
            anim.SetTrigger("Damage");
            health -= damage;
            CalculateHealth();
        }
    }
    protected virtual void DieSound()
    {
        GameEvents.DeathSound?.Invoke();
    }
    protected virtual void Die()
    {
        //if (slider != null) slider.enabled = false;
        GameEvents.GetXP?.Invoke(xpPoints);
        Destroy(gameObject);
    }

    private void Update()
    {
        if (health <= 0f) // if true, Die
        {
            if (canDie)
            {
                //Toggle canDie
                anim.SetTrigger("Death");
                canDie = false;
                //Add Die function as event in death animator
            }
        }
        if(imageFill != null) imageFill.fillAmount = CurrentHealth;
        
        //if (slider != null)
        //{
        //    // update health slider
        //    slider.value = CalculateHealth();
        //}
    }
    void CalculateHealth()
    {
        CurrentHealth = health / maxHealth;
    }
}