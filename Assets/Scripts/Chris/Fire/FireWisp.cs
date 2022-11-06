using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FireWisp : FireState
{
    public FireWisp(GameObject _npc, NavMeshAgent _agent, Animator _anim, GameObject _player)
        : base(_npc, _agent, _anim, _player)
    {
        name = FIRESTATE.Wisp;
    }

    public override void Enter()
    {
        wheat = npc.GetComponent<DetectWheat>();
        rb = npc.GetComponent<Rigidbody>();
        spawner = npc.GetComponent<WispSpawner>();
        timer = npc.GetComponent<FireTimer>();
        prox = npc.GetComponent<ProximityDamage>();
        shoot = npc.transform.GetComponentInChildren<FireBallShoot>();

        anim.SetTrigger("BecomeWisp");
        shoot.ShootStop();
        prox.distance = 2;
        prox.damage = 1;
        npc.transform.LeanScale(new Vector3(1, 1, 1), 1);
        agent.speed = 8f;
        wheat.FindWheat();
        base.Enter();
    }

    public override void Update()
    {
        agent.destination = wheat.closestWheatPatch;
        if (wheat.inWheat)
        {
            nextState = new FireBall(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        anim.ResetTrigger("BecomeWisp");
        base.Exit();
    }
}