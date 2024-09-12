using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GruntAi : MonoBehaviour
{
    
    NavMeshAgent agent;
    Animator anim;
    private GameObject player;
    State currentState;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        agent = this.GetComponent<NavMeshAgent>();
        anim = this.GetComponent<Animator>();
        currentState = new Normal(gameObject, agent, anim, player);
    }

    // Update is called once per frame
    void Update()
    {
        currentState = currentState.Process();
    }

  
}

