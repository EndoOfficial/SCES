using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillDamage : Enemy
{
    private int damage = 5;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Destroys the object when it hits you
            TakeDamage(1000, gameObject);
            // damages the player
            GameEvents.DamagePlayer?.Invoke(damage);
        }
    }
}
