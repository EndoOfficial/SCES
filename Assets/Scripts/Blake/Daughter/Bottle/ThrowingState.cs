using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ThrowingState : BottleState
{
    Enemy enemy;
    float tempHealth;

    public ThrowingState(GameObject _npc, NavMeshAgent _agent, Animator _anim, GameObject _player)
        : base(_npc, _agent, _anim, _player)
    {
        name = PILLBOTTLESTATE.DEFAULT;
    }
    public override void Enter()
    {
        enemy = npc.GetComponent<Enemy>();
        tempHealth = enemy.health;
        //anim.SetTrigger("Throw");
        base.Enter();
    }

    public override void Update()
    {
        if(enemy.health < tempHealth)
        {
            nextState = new DamagedState(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
       // anim.ResetTrigger("Throw");
        base.Exit();
    }
    

}