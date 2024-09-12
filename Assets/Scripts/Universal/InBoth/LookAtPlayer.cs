using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer: MonoBehaviour
{
    private Transform player;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>(); // get player position
    }

    private void Update()
    {
        if (player)
        {
            transform.LookAt(player); // look at player position
        }
    }
}