using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Normal : GruntState
{

    Grunts Grunt;
    HeadShot head;
  
    public Normal(GameObject _npc, NavMeshAgent _agent, Animator _anim, GameObject _player)
        : base(_npc, _agent, _anim, _player)
    {
        name = GRUNTSTATE.NORMAL;
    }
    public override void Enter()
    {
        anim.SetTrigger("GetUp");
        rb = npc.GetComponent<Rigidbody>();
        Grunt = npc.GetComponent<Grunts>();
        head = npc.GetComponentInChildren<HeadShot>();
        npc.GetComponent<CapsuleCollider>().height = 2;
        npc.GetComponent<CapsuleCollider>().center = Vector3.zero;
        Grunt.speedEffect = 1f;
        Grunt.damage = 2;
        base.Enter();
    }

    public override void Update()
    {

        if (head.left==true)
        {
            nextState = new LeftKnee(npc, agent, anim, player); 
            
            stage = EVENT.EXIT;
        }
        
        if (head.right == true)
        {
            nextState = new RightKnee(npc, agent, anim, player); 
            
            stage = EVENT.EXIT;
        }
    }
    public override void Exit()
    {
        anim.ResetTrigger("GetUp");
        base.Exit();
    }
}

