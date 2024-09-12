using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PillRetreatState : PillState
{
    RetreatTimer Timer;
    PillMovement Running;
    public PillRetreatState(GameObject _npc, NavMeshAgent _agent, Animator _anim, GameObject _player)
    : base(_npc, _agent, _anim, _player)
    {
        name = PILLSTATE.RETREAT;
    }
    public override void Enter()
    {
        anim = npc.GetComponent<Animator>();
        anim.SetTrigger("RunBackwards");
        Timer = npc.GetComponent<RetreatTimer>();
        Timer.ReatreatTimer();
        Running = npc.GetComponent<PillMovement>();
        Running.speed = -6f;
        base.Enter();
    }
    public override void Update()
    {
        if (Timer.TimesUp == true)
        {
            Timer.TimesUp = false;
            nextState = new PillAttackState(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
    }
    public override void Exit()
    {
        anim.ResetTrigger("RunBackwards");
        base.Exit();
    }
}