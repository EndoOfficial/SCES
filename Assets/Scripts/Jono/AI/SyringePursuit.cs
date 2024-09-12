using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyringePursuit : SyringeState
{
    SyringeAI ai;
    SyringeJump Jump;
    bool JumpToRoof;
    
    public SyringePursuit(GameObject _npc,Animator _anim, GameObject _player)
        : base(_npc,_anim, _player)
    {
        name = SyringeSTATE.PURSUIT;
    }

    public override void Enter()
    {
        rb = NPC.GetComponent<Rigidbody>();
        ai = NPC.GetComponent<SyringeAI>();
        Jump = NPC.GetComponent<SyringeJump>();
        base.Enter();
    }

    public override void Update()
    {
        Jump.IsJumping();

        if (!ai.Detected)
        {
            nextState = new SyringeIdle(NPC,Anim, player);
            stage = EVENT.EXIT;
        }

        if (ai.JumpToRoof)
        {
            nextState = new SyringeTurret(NPC,Anim, player);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
