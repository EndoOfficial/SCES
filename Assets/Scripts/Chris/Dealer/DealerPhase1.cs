using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DealerPhase1 : DealerState
{
    private Enemy enemy;
    public DealerPhase1(GameObject _npc, NavMeshAgent _agent, Animator _anim, GameObject _player)
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
        if (enemy.health <= 800)
        {
            nextState = new DealerPhase2(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        anim.ResetTrigger("isIdle");
        base.Exit();
    }
}
