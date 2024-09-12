using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CiggsState : State
{
    public CIGGSSTATE name;
    public enum CIGGSSTATE
    {
         RAGE1, RAGE2, RAGE3, RAGE4
    }

    public CiggsState(GameObject _npc, NavMeshAgent _agent, Animator _anim, GameObject _player)
        :base(_npc, _agent, _anim, _player)
    {
        
    }

    public override void Enter() { stage = EVENT.UPDATE; }
    public override void Update() { stage = EVENT.UPDATE; }
    public override void Exit() { stage = EVENT.EXIT; }

   

}