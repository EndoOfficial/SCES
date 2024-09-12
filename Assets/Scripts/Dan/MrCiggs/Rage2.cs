using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Rage2 : CiggsState
{

    MrCiggs ciggs;
    EnemyGun shot;

    public Rage2(GameObject _npc, NavMeshAgent _agent, Animator _anim, GameObject _player)
        : base(_npc, _agent, _anim, _player)
    {
        name = CIGGSSTATE.RAGE2;
    }

    public override void Enter()
    {
        anim.SetTrigger("Rage2");
        rb = npc.GetComponent<Rigidbody>();
        ciggs = npc.GetComponent<MrCiggs>();
        shot = npc.GetComponent<EnemyGun>();
        shot.attackSpeed = 0.5f;
        shot.damage = 3;
        base.Enter();
    }

    public override void Update()
    {
       
        if (ciggs.rage >= 50)
        {
            nextState = new Rage3(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
        if (ciggs.rage <= 25)
        {
            nextState = new Rage1(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }

    }

    public override void Exit()
    {
        anim.ResetTrigger("Rage2");
        base.Exit();
    }

}
