using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TwoKnee : GruntState
{
    HeadShot head;
    Grunts Grunt;
  
    public TwoKnee(GameObject _npc, NavMeshAgent _agent, Animator _anim, GameObject _player)
        : base(_npc, _agent, _anim, _player)
    {
        name = GRUNTSTATE.TWOKNEE;
    }
    public override void Enter()
    {
        anim.SetTrigger("BothLegDowning");
        rb = npc.GetComponent<Rigidbody>();
        Grunt = npc.GetComponent<Grunts>();
        head = npc.GetComponentInChildren<HeadShot>();
        
        Grunt.speedEffect = 0f;
        Grunt.damage = 0;
        base.Enter();
    }

    public override void Update()
    {
        if (head.head==false)
        {
            nextState = new Normal(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
    }
    public override void Exit()
    {
        anim.ResetTrigger("BothLegDowning");
        base.Exit();
    }
}

