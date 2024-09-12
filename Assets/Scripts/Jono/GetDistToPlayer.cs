using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDistToPlayer : MonoBehaviour
{
    public GameObject Player;
    public float PlayerDist;
  
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    
    void Update()
    {
        //Gets distance from player to object with this script as float value.
        PlayerDist = Vector3.Distance(transform.position, Player.transform.position);        
    }
}
