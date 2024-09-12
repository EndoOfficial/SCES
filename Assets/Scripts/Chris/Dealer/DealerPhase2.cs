using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DealerPhase2 : DealerState
{
    private Enemy enemy;
    public DealerPhase2(GameObject _npc, NavMeshAgent _agent, Animator _anim, GameObject _player)
        : base(_npc, _agent, _anim, _player)
    {
        name = DEALERSTATE.PHASE1;
    }

    public override void Enter()
    {
        anim.SetTrigger("isIdle");
        base.Enter();
        enemy = npc.GetComponent<Enemy>();
    }

    public override void Update()
    {

    }

    public override void Exit()
    {
        anim.ResetTrigger("isIdle");
        base.Exit();
    }
}
