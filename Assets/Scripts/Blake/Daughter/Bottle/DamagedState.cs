using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DamagedState : BottleState
{
    float Health;
    public DamagedState(GameObject _npc, NavMeshAgent _agent, Animator _anim, GameObject _player)
        : base(_npc, _agent, _anim, _player)
    {
        name = PILLBOTTLESTATE.DAMAGED;
        Health = npc.GetComponent<BottleEnemy>().health;
    }
    public override void Enter()
    {
        //anim.SetTrigger("Damage");
        base.Enter();

    }
    public override void Update()
    {
        if (Health <= 0)
        {
            anim.SetTrigger("Death");
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        //anim.ResetTrigger("Damage");
        base.Exit();
    }
}