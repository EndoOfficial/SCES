using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FishState : State
{
    public FISHSTATE name;

    public enum FISHSTATE
    {
        IDLE, PURSUIT, ATTACK
    }

    public FishState(GameObject _npc, NavMeshAgent _agent, Animator _anim, GameObject _player)
        : base(_npc, _agent, _anim, _player)
    {

    }

    public override void Enter() { stage = EVENT.UPDATE; }
    public override void Update() { stage = EVENT.UPDATE; }
    public override void Exit() { stage = EVENT.EXIT; }
}