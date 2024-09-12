using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FishPursuit : FishState
{
    FishJump jump;
    PlayerDetect detect;
    public FishPursuit(GameObject _npc, NavMeshAgent _agent, Animator _anim, GameObject _player)
        : base(_npc, _agent, _anim, _player)
    {
        name = FISHSTATE.PURSUIT;
    }

    public override void Enter()
    {
        rb = npc.GetComponent<Rigidbody>();
        jump = npc.GetComponent<FishJump>();
        detect = npc.GetComponent<PlayerDetect>();
        base.Enter();
    }

    public override void Update()
    { 
        // sets jumpDirection to the direction of the player
        jump.jumpDirection = player.transform.position - npc.transform.position;
        if (!detect.range)
        {
            nextState = new FishIdle(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}