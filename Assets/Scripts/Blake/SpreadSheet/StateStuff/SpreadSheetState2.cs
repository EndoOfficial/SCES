using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpreadSheetState2 : SpreadSheetState
{
    private CellSpawner CellSpawner;
    private Enemy SpreadSheet;
    public SpreadSheetState2(GameObject _npc, NavMeshAgent _agent, Animator _anim, GameObject _player)
        : base(_npc, _agent, _anim, _player)
    {

    }
    public override void Enter()
    {
        CellSpawner = npc.GetComponent<CellSpawner>();

        CellSpawner.SpawnLimit = 20;
        CellSpawner.SpawnDealChance = 38;
        CellSpawner.State2 = true;
        // ensures more cells spawn and there is a lesser
        // chance of spawning cells to deal damage to the boss
        // as well as colour setting in the cells

        SpreadSheet = npc.GetComponent<Enemy>();
        base.Enter();
    }
    public override void Update()
    {
        if (SpreadSheet.health <= SpreadSheet.maxHealth/3) // made dynamic so if max health is changed
        {
            nextState = new SpreadSheetState3(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
