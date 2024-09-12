using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauseSpreadDeath : MonoBehaviour
{
    public int Count;
    public void die()
    {
        Destroy(this);
    }
    public void Counter()
    {
        Count += 1;
        if(Count >= 7)
        {
            GameEvents.KillSpread?.Invoke();
        }
    }
}
