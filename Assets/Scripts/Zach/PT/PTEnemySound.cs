using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PTEnemySound : Enemy
{
    //private AudioCycle audioCycle;
    private AudioSource source;


    protected override void Start()
    {
        base.Start();
        //audioCycle = GetComponent<AudioCycle>();
        source = GetComponent<AudioSource>();
    }

    protected override void TakeDamage(int damage, GameObject target)
    {
        if (gameObject == target)
        {
            anim.SetTrigger("Death");
        }
    }

    //private void OnEnable()
    //{
    //    GameEvents.DeathSound += DeathAudio;
    //}
    //private void OnDisable()
    //{
    //    GameEvents.DeathSound -= DeathAudio;
    //}
    void DeathAudio()
    {
        GameEvents.OnRuralplayAudio?.Invoke(source, AudioManager.RuralClipTags.TargetDeath);
    }
}
