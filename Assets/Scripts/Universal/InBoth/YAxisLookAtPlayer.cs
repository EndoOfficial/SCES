using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YAxisLookAtPlayer : MonoBehaviour
{
    private Transform player;
    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }
    private void Update()
    {       
        transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
    }
}
