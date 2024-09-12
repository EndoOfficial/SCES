using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallRespawn : MonoBehaviour
{
    public GameObject SpawnPoint;
    private int damage;
    public int Health;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("KillBox"))
        {
            transform.position = SpawnPoint.transform.position;

            if(Health <= 10)
            {
                damage = Health - 1;
            }
            else
            {
                damage = 10;
            }
            GameEvents.DamagePlayer(damage);
        }
    }
}
