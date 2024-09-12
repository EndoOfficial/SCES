using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Rage3 : CiggsState
{

    MrCiggs ciggs;
    EnemyGun shot;

    public Rage3(GameObject _npc, NavMeshAgent _agent, Animator _anim, GameObject _player)
        : base(_npc, _agent, _anim, _player)
    {
        name = CIGGSSTATE.RAGE3;
    }

    public override void Enter()
    {
        anim.SetTrigger("Rage3");
        rb = npc.GetComponent<Rigidbody>();
        ciggs = npc.GetComponent<MrCiggs>();
        shot = npc.GetComponent<EnemyGun>();
        shot.attackSpeed = 0.4f;
        shot.damage = 5;
        base.Enter();
    }

    public override void Update()
    {
        
        if (ciggs.rage >= 75)
        {
            nextState = new Rage4(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
        if (ciggs.rage <= 50)
        {
            nextState = new Rage2(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }

    }

    public override void Exit()
    {
        anim.ResetTrigger("Rage3");
        base.Exit();
    }

}
