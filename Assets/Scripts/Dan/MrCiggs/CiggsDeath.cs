using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CiggsDeath : Enemy
{
    protected override void Die()
    {
        //image.enabled = false;
        GameEvents.LevelWin?.Invoke();
        base.Die();
    }
}
