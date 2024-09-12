using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class State
{
    public enum STATE
    {
        IDLE
    }
    
    public enum EVENT
    {
        ENTER, UPDATE, EXIT
    }

    
    protected EVENT stage;
    protected GameObject npc;
    protected Animator anim;
    protected GameObject player;
    protected State nextState;
    protected NavMeshAgent agent;
    protected Rigidbody rb;
    protected bool grounded;

    public State(GameObject _npc, NavMeshAgent _agent, Animator _anim, GameObject _player)
    {
        npc = _npc;
        agent = _agent;
        anim = _anim;
        stage = EVENT.ENTER;
        player = _player;
    }

    public virtual void Enter() { stage = EVENT.UPDATE; }
    public virtual void Update() { stage = EVENT.UPDATE; }
    public virtual void Exit() { stage = EVENT.EXIT; }

    public State Process()
    {
        if (stage == EVENT.ENTER) Enter();
        if (stage == EVENT.UPDATE) Update();
        if (stage == EVENT.EXIT)
        {
            Exit();
            return nextState;
        }
        return this;
    }

}