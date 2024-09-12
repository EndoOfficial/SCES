using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CokePursuit : CokeEnemyState
{
    Mrcoke2 MrCocaine;
    PuffPatchChecker check;
    private Vector3 playersPosition;
    public CokePursuit(GameObject _npc, NavMeshAgent _agent, Animator _anim, GameObject _player)
        : base(_npc, _agent, _anim, _player)
    {
        name = COKEENEMYSTATE.PURSUIT;
    }
    public override void Enter()
    {
        playersPosition = player.transform.position;
        check = npc.GetComponent<PuffPatchChecker>();
        MrCocaine = npc.GetComponent<Mrcoke2>();
        anim.SetTrigger("Pursuit");
        rb = npc.GetComponent<Rigidbody>();
        //GameEvents.CokeTarget?.Invoke();
        
        MrCocaine.target = player;
        agent.SetDestination(playersPosition);
        /*agent.SetDestination(player.transform.position)*/ // targets the player
        base.Enter();
    }
    public override void Update()
    {
         playersPosition = player.transform.position;
        agent.SetDestination(playersPosition);
        if (check.Pursue == false)
        {
            
            anim.SetTrigger("Patrol");
            nextState = new PatrolState(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
    }
    public override void Exit()
    {
        anim.ResetTrigger("Pursuit");
        base.Exit();
    }
}
