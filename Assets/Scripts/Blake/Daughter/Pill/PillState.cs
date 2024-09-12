using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PillState : State
{
    public PILLSTATE name;
    public enum PILLSTATE
    {
        FORWARD, ATTACK, RETREAT, DEAD
    }
    public override void Enter() { stage = EVENT.UPDATE; }
    public override void Update() { stage = EVENT.UPDATE; }
    public override void Exit() { stage = EVENT.EXIT; }

    public PillState(GameObject _npc, NavMeshAgent _agent, Animator _anim, GameObject _player)
        : base(_npc, _agent, _anim, _player)
    {
        
    }
}
