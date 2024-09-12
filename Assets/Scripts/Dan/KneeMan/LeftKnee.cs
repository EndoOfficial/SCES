using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LeftKnee : GruntState
{
    Grunts Grunt;
    HeadShot head;
    public LeftKnee(GameObject _npc, NavMeshAgent _agent, Animator _anim, GameObject _player)
        : base(_npc, _agent, _anim, _player)
    {
        name = GRUNTSTATE.LEFTKNEE;
    }
    public override void Enter()
    {
        anim.SetTrigger("LeftLegDowning");
        rb = npc.GetComponent<Rigidbody>();
        Grunt = npc.GetComponent<Grunts>();
        head = npc.GetComponentInChildren<HeadShot>();
        npc.GetComponent<CapsuleCollider>().height = 1;
        npc.GetComponent<CapsuleCollider>().center = new Vector3(0, -0.5f, 0);
        Grunt.speedEffect = 0f;
        Grunt.damage = 0;
        base.Enter();
    }

    public override void Update()
    {

        if (head.left == false && head.right == false)
        {
            nextState = new Normal(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }

        if (head.head)
        {
            nextState = new TwoKnee(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
    }
    public override void Exit()
    {
        anim.ResetTrigger("LeftLegDowning");
        base.Exit();
    }
}

