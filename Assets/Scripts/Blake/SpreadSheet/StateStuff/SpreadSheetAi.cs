using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpreadSheetAi : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;
    private GameObject player;
    State currentState;

    void Start()
    {
        currentState = new SpreadSheetState1(gameObject, agent, anim, player);
    }
    void Update()
    {
        currentState = currentState.Process();
    }
    private void OnEnable()
    {
        GameEvents.KillSpread += Die;
    }
    private void OnDisable()
    {
        GameEvents.KillSpread -= Die;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
