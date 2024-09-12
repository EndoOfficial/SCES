using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CiggsAI : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;
    private GameObject player;
    State currentState;
    public bool detected;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        agent = this.GetComponent<NavMeshAgent>();
        anim = this.GetComponent<Animator>();
        currentState = new Rage1(gameObject, agent, anim, player);
    }

    // Update is called once per frame
    void Update()
    {
        currentState = currentState.Process();
    }

    private void OnEnable()
    {
        GameEvents.DetectPlayer += DetectPlayer;
    }

    private void OnDisable()
    {
        GameEvents.DetectPlayer -= DetectPlayer;
    }

    private void DetectPlayer(bool detect)
    {
        //passthrough a bool
        if (detect) { detected = true; }
        else { detected = false; }
    }
}
