using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PillBottleAI : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;
    public GameObject player;
    State currentState;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        currentState = new ThrowingState(gameObject, agent, anim, player);
    }
    void Update()
    {
        currentState = currentState.Process();
    }
}
