using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyringeTurret : SyringeState
{
    SyringeAI AI;
    SyringeJump Turret;
    public SyringeTurret(GameObject _npc, Animator _anim, GameObject _player)
        : base(_npc, _anim, _player)
    {
        name = SyringeSTATE.TURRET;
    }
    public override void Enter()
    {
        Debug.Log("Syringe Turret");
        
        rb = NPC.GetComponent<Rigidbody>();
        AI = NPC.GetComponent<SyringeAI>();
        Turret = NPC.GetComponent<SyringeJump>();
        

        base.Enter();
    }

    public override void Update()
    {
        if (AI.grounded)
        {
            Turret.IsTurret();
        }
        if (!AI.Turretable)
        {
            nextState = new SyringePursuit(NPC,Anim, player);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        Debug.Log("Syringe left Turret");
        base.Exit();
    }
}
