using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool Grounded;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground")
        {
            Grounded = true;            
        }
    }

    void OnTriggerExit(Collider target)
    {
        if (target.tag == "Ground")
        {
            Grounded = false;
        }
    }
}
