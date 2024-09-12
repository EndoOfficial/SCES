using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FireNado : FireState
{
    public FireNado(GameObject _npc, NavMeshAgent _agent, Animator _anim, GameObject _player)
        : base(_npc, _agent, _anim, _player)
    {
        name = FIRESTATE.Tornado;
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

        anim.SetTrigger("BecomeTornado");
        enemy.maxHealth = enemy.tornadoHealth;
        enemy.IsTornado();
        spawner.startSpawn();
        shoot.FireRate = 1;
        timer.StopTimer();
        prox.distance = 20;
        prox.damage = 10;
        npc.transform.LeanScale(new Vector3(6, 6, 6), 1);
        var moveDirection = (npc.transform.position - player.transform.position).normalized;
        var moveTarget = new Vector3(npc.transform.position.x + (moveDirection.x * 20), 0, npc.transform.position.x + (moveDirection.z * 20));
        LeanTween.move(npc.gameObject, moveTarget, 2);
        wheat.interval = 10;
        agent.speed = 2f;
        agent.isStopped = false;
        base.Enter();
    }

    public override void Update()
    {
        agent.destination = wheat.closestWheatPatch;
        if (enemy.beFire)
        {
            enemy.beFire = false;
            nextState = new FireBall(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        anim.ResetTrigger("BecomeTornado");
        base.Exit();
    }
}