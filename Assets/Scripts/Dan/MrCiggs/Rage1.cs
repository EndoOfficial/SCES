using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Rage1 : CiggsState
{
    MrCiggs ciggs;
    EnemyGun shot;
    
    public Rage1(GameObject _npc, NavMeshAgent _agent, Animator _anim, GameObject _player)
        : base(_npc, _agent, _anim, _player)
    {
        name = CIGGSSTATE.RAGE1;
    }

    public override void Enter()
    {
        anim.SetTrigger("Rage1");
        rb = npc.GetComponent<Rigidbody>();
        ciggs = npc.GetComponent<MrCiggs>();
        shot = npc.GetComponent<EnemyGun>();
        shot.attackSpeed = 1f;
        shot.damage = 1;
        base.Enter();
    }
    public override void Update()
    {
       
        if (ciggs.rage>=25)
        {
            nextState = new Rage2(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        anim.ResetTrigger("Rage1");
        base.Exit();
    }
   
}

