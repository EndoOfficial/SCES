using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Idle : State
{
    AI ai;
    public Idle(GameObject _npc, NavMeshAgent _agent, Animator _anim, GameObject _player)
        : base(_npc, _agent, _anim, _player)
    {
        name = STATE.IDLE;
    }

    public override void Enter()
    {
        anim.SetTrigger("isIdle");
        rb = npc.GetComponent<Rigidbody>();
        ai = npc.GetComponent<AI>();
        base.Enter();
    }

    public override void Update()
    {
        Debug.Log("Idle");
        if (ai.detected)
        {
            Debug.Log("here");
            nextState = new Pursuit(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
        base.Update();
    }

    public override void Exit()
    {
        anim.ResetTrigger("isIdle");
        base.Exit();
    }
}