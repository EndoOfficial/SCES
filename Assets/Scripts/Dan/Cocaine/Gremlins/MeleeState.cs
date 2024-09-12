using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeState : CokeEnemyState
{

    Mrcoke2 MrCocaine;
    PuffPatchChecker check;
    public MeleeState(GameObject _npc, NavMeshAgent _agent, Animator _anim, GameObject _player)
        : base(_npc, _agent, _anim, _player)
    {
        name = COKEENEMYSTATE.MELEE;
    }
    public override void Enter()
    {
        check = npc.GetComponent<PuffPatchChecker>();
        //anim.SetTrigger("Patrol");
        rb = npc.GetComponent<Rigidbody>();
        MrCocaine = npc.GetComponent<Mrcoke2>();
        base.Enter();
    }
    public override void Update()
    {

        if (check.Pursue == false)
        {
            Debug.Log("Patrol");
            nextState = new PatrolState(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }


    }
    public override void Exit()
    {
        //anim.ResetTrigger("Patrol");
        base.Exit();
    }
}


   
