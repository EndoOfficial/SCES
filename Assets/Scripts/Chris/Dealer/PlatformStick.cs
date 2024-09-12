using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformStick : PlayerMovement
{

    private void Update()
    {
        // ground check raycast
        isGrounded = Physics.Raycast(transform.position, Vector3.down, out RaycastHit hitinfo, dist, groundMask);

        //if the ground has "Paper" tag
        if (isGrounded && hitinfo.transform.CompareTag("Paper"))
        {
            transform.parent = hitinfo.transform; // makes the player a child of the platform
        }
        else
        {
            transform.parent = null; // unparents everything from the player
        }
    }
}