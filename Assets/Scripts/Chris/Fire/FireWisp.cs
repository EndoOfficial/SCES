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
        shoot = npc.GetComponent<FireBallShoot>();
        enemy = npc.GetComponent<FireEnemy>();

        //change all data to become Wisp
        anim.SetTrigger("BecomeWisp");
        enemy.maxHealth = enemy.wispHealth;
        enemy.IsWisp();
        shoot.ShootStop();
        spawner.stopSpawn();
        prox.distance = 2;
        prox.damage = 1;
        timer.StopTimer();
        npc.transform.LeanScale(new Vector3(1, 1, 1),1);
        agent.speed = 10f;
        wheat.FindWheat();
        agent.isStopped = false;
        wheat.interval = 1;
        base.Enter();
    }

    public override void Update()
    {
        agent.destination = wheat.closestWheatPatch;
        if (wheat.inWheat)// change to FireBall when they touch wheat
        {
            wheat.inWheat = false; 
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