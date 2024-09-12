using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpreadSheetState1 : SpreadSheetState
{
    private Enemy SpreadSheet;
    public SpreadSheetState1(GameObject _npc, NavMeshAgent _agent, Animator _anim, GameObject _player)
        : base(_npc, _agent, _anim, _player)
    {

    }
    public override void Enter()
    {
        SpreadSheet = npc.GetComponent<Enemy>();
        base.Enter();
    }
    public override void Update()
    {
        if (SpreadSheet.health <= SpreadSheet.maxHealth/3 * 2) // made dynamic so if max health is changed
        {
            nextState = new SpreadSheetState2(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
