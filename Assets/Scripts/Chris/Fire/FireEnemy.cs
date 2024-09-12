using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEnemy : Enemy
{
    /*
        this code tells the states when to change because they took damage
    */
    public int wispHealth;
    public int fireballHealth;
    public int tornadoHealth;

    private bool isWisp;
    private bool isFireball;
    private bool isTornado;

    public bool beWisp = false;
    public bool beFire = false;

    protected override void TakeDamage(int damage, GameObject target)
    {
        if (gameObject == target)
        {
            base.TakeDamage(damage, target);
            if (health <= 0)
            {
                if (isWisp)
                {
                    Die();
                }
                else if (isFireball)
                {
                    beWisp = true;
                    beFire = false;
                    canDie = false;
                }
                else if (isTornado)
                {
                    beWisp = false;
                    beFire = true;
                    canDie = false;
                }
            }
        }
    }

    public void IsWisp()
    {
        image.gameObject.SetActive(false);
        imageFill.gameObject.SetActive(false);
        health = maxHealth;
        isWisp = true;
        isFireball = false;
        isTornado = false;
    }

    public void IsFireball()
    {
        image.gameObject.SetActive(true);
        imageFill.gameObject.SetActive(true);
        health = maxHealth;
        isWisp = false;
        isFireball = true;
        isTornado = false;
    }

    public void IsTornado()
    {
        image.gameObject.SetActive(true);
        imageFill.gameObject.SetActive(true);
        health = maxHealth;
        isWisp = false;
        isFireball = false;
        isTornado = true;
    }
}
