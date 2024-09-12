using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FishIdle : FishState
{
    PlayerDetect detect;
    FishJump jump;
    public FishIdle(GameObject _npc, NavMeshAgent _agent, Animator _anim, GameObject _player)
        : base(_npc, _agent, _anim, _player)
    {
        name = FISHSTATE.IDLE;
    }

    public override void Enter()
    {
        rb = npc.GetComponent<Rigidbody>();
        jump = npc.GetComponent<FishJump>();
        detect = npc.GetComponent<PlayerDetect>();
        jump.jumpDirection = Vector3.zero;
        base.Enter();
    }

    public override void Update()
    {
        if (detect.range)// if player is detected
        {
            nextState = new FishPursuit(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}