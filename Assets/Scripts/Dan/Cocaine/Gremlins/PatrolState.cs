using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PatrolState : CokeEnemyState
{
    Mrcoke2 MrCocaine;
    PuffPatchChecker check;
    public PatrolState(GameObject _npc, NavMeshAgent _agent, Animator _anim, GameObject _player)
        : base(_npc, _agent, _anim, _player)
    {
        name = COKEENEMYSTATE.PATROL;
    }
    public override void Enter()
    {
        check = npc.GetComponent<PuffPatchChecker>();
        anim.SetTrigger("Patrol");
        rb = npc.GetComponent<Rigidbody>();
        MrCocaine = npc.GetComponent<Mrcoke2>();
        MrCocaine.Retarget(); // checks to seee if patches are targetable
        base.Enter();
    }
    public override void Update()
    {
        if (check.Pursue)
        {
           
            anim.SetTrigger("Pursuit");
            nextState = new CokePursuit(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
    }
    public override void Exit()
    {
        anim.ResetTrigger("Patrol");
        base.Exit();
    }
}