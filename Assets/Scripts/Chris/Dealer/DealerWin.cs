using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealerWin : Enemy
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void TakeDamage(int damage, GameObject target)
    {
        base.TakeDamage(damage, target);
    }

    protected override void Die()
    {
        GameEvents.LevelWin?.Invoke();
        base.Die();
    }
}
