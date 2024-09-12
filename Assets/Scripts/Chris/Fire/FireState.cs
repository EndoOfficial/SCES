using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FireState : State
{
    public FIRESTATE name;
    protected FireTimer timer;
    protected DetectWheat wheat;
    protected WispSpawner spawner;
    protected FireBallShoot shoot;
    protected ProximityDamage prox;
    protected FireEnemy enemy;
    public enum FIRESTATE
    {
        Wisp, Fire, Tornado
    }

    public FireState(GameObject _npc, NavMeshAgent _agent, Animator _anim, GameObject _player)
        : base(_npc, _agent, _anim, _player)
    {

    }

    public override void Enter() { stage = EVENT.UPDATE; }
    public override void Update() { stage = EVENT.UPDATE; }
    public override void Exit() { stage = EVENT.EXIT; }
}