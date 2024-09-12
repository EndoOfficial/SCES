using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PillAttackState : PillState
{
    RetreatTimer Timer;
    PillMovement Running;
    HitPlayer Hit;
    public PillAttackState(GameObject _npc, NavMeshAgent _agent, Animator _anim, GameObject _player)
    : base(_npc, _agent, _anim, _player)
    {
        name = PILLSTATE.ATTACK;
    }
    public override void Enter()
    {
        anim = npc.GetComponent<Animator>();
        Timer = npc.GetComponent<RetreatTimer>();
        Hit = npc.GetComponent<HitPlayer>();
        Running = npc.GetComponent<PillMovement>();
        Running.speed = 2f;
        base.Enter();
    }
    public override void Update()
    {
        if (Hit.Attacked == true)
        {
            Hit.Attacked = false;
            anim.SetTrigger("Attack");
        }
        if (Timer.Attack == true)
        {
            Timer.Attack = false;
            nextState = new PillRetreatState(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
    }
    public override void Exit()
    {
        anim.ResetTrigger("RunForwards");
        base.Exit();
    }
}