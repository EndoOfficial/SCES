using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpreadSheetState : State
{
    public SPREADSHEETSTATE name;
    public enum SPREADSHEETSTATE
    {
        SpreadSheetState1, SpreadSheetState2, SpreadSheetState3
    }
    public override void Enter() { stage = EVENT.UPDATE; }
    public override void Update() { stage = EVENT.UPDATE; }
    public override void Exit() { stage = EVENT.EXIT; }

    public SpreadSheetState(GameObject _npc, NavMeshAgent _agent, Animator _anim, GameObject _player)
        : base(_npc, _agent, _anim, _player)
    {

    }
    
}
