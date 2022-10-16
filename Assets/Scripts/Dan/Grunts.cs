using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grunts : MonoBehaviour
{
    public float speed;
    public float speedEffect = 1;
    public LayerMask Player;
    public float radius;
    public int damage;

    public bool hit;
    void Update()
    {
        transform.position += transform.forward * speed * speedEffect * Time.deltaTime;
        if (Physics.CheckSphere(transform.position, radius, Player))
        {
            if (!hit)
            {
                hit = true;
                GameEvents.DamagePlayer?.Invoke(damage);
            }
        }
        else
        {
            hit = false;
        }
    }
   

}