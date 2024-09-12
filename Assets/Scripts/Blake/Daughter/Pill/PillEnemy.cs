using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillEnemy : MonoBehaviour
{
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        GameEvents.BottleDeath += KillAll;
    }

    private void OnDisable()
    {
        GameEvents.BottleDeath += KillAll;
    }

    public void KillAll()
    {
        if (anim != null) 
        {
            anim.SetTrigger("Death"); 
        }
    }
}
