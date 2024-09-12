using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillMove : MonoBehaviour
{
    public float speed;
    private bool dead = false;
    void Start()
    {
        transform.parent = null;
    }

    void FixedUpdate()
    {
        // Moves forward
        if (!dead)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }

    protected void SetLayer()
    {
        dead = true;
        gameObject.layer = 2;
    }
}