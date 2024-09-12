using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpreadSheetState3 : SpreadSheetState
{
    private CellSpawner CellSpawner;
    private TentacleAnimator Thrower;
    public SpreadSheetState3(GameObject _npc, NavMeshAgent _agent, Animator _anim, GameObject _player)
        : base(_npc, _agent, _anim, _player)
    {

    }
    public override void Enter()
    {
        anim = npc.GetComponent<Animator>();
        CellSpawner = npc.GetComponent<CellSpawner>();
        Thrower = npc.GetComponentInChildren<TentacleAnimator>();

        CellSpawner.SpawnLimit = 30;
        CellSpawner.SpawnDealChance = 25;
        Thrower.ThrowChance = 65;
        CellSpawner.State2 = false;
        CellSpawner.State3 = true;

        // ensures more cells spawn and there is a lesser
        // chance of spawning cells to deal damage to the boss
        // as well as colour setting in the cells
        base.Enter();
    }
    public override void Exit()
    {
        base.Exit();
    }
}
