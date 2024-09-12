using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MiniPillAI : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;
    private GameObject player;
    State currentState;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        currentState = new PillAttackState(gameObject, agent, anim, player);
    }
    void Update()
    {
        currentState = currentState.Process();
    }
}
