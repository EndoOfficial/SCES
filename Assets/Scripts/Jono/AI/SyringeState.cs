using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SyringeState
{
    
    public enum SyringeSTATE
    {
        IDLE, PURSUIT, JUMP, TURRET
    };
   public enum EVENT
    {
        ENTER, UPDATE, EXIT
    };

    public SyringeSTATE name;
    protected EVENT stage;
    protected GameObject NPC;
    protected GameObject player;
    protected Animator Anim;
    protected SyringeState nextState;
    protected Rigidbody rb;


    

    public SyringeState (GameObject _npc,Animator _anim, GameObject _player)
    {
        NPC = _npc;
        player = _player;
        Anim = _anim;
    }

    public virtual void Enter() { stage = EVENT.UPDATE; }
    public virtual void Update() { stage = EVENT.UPDATE; }
    public virtual void Exit() { stage = EVENT.EXIT; }

    public SyringeState Process()
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
