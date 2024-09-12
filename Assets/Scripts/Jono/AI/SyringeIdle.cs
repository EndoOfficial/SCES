using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.AI; << wrong move buccko
using UnityEngine.AI;

public class SyringeIdle : SyringeState
{
    SyringeAI AI;
    public SyringeIdle (GameObject _npc, Animator _anim, GameObject _player)
        : base(_npc,_anim, _player)
    {
        name = SyringeSTATE.IDLE;
    }
    public override void Enter()
    {

        rb = NPC.GetComponent<Rigidbody>();
        AI = NPC.GetComponent<SyringeAI>();        
        base.Enter();
    }

    public override void Update()
    {
        if (AI.Detected)
        {
            nextState = new SyringePursuit(NPC,Anim, player);
            stage = EVENT.EXIT;
        }   
        if(!AI.Turretable)
        {
            nextState = new SyringePursuit(NPC,Anim, player);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }


}
