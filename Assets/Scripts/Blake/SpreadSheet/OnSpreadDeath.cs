using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSpreadDeath : MonoBehaviour
{
    private Animator Anim;
    void Start()
    {
        Anim = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        GameEvents.KillSpread += Die;
    }

    private void OnDisable()
    {
        
        GameEvents.KillSpread -= Die;
    }
    private void Die()
    {
        Anim.SetTrigger("Die");
    }
    private void Death()
    {
        GameEvents.LevelWin?.Invoke();
        Destroy(gameObject);
    }
}
