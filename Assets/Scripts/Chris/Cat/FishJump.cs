using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishJump : MonoBehaviour
{
    public float waitTime;
    private Rigidbody rb;
    public bool grounded;
    public Vector3 jumpDirection;
    private Animator anim;
    private float temp;
    private AOE aoe;
    public float jump = 6;

    private void Start()
    {
        //get components
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        aoe = GetComponent<AOE>();
        temp = waitTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            grounded = true;
            aoe.aoe();
            GameEvents.OnSlumsplayAudio?.Invoke(GetComponent<AudioSource>(), AudioManager.SlumsClipTags.FishLand);
            StartCoroutine(Wait()); // start co-routine
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        grounded = false;
    }

    private IEnumerator Wait()
    {
        if (grounded)
        {
            waitTime = temp * UnityEngine.Random.Range(0.8f, 1.2f);
            yield return new WaitForSecondsRealtime(waitTime);
            grounded = false;

            rb.velocity = new Vector3(0, 0, 0);//reset velocity
            //clamp velocity
            jumpDirection.x = Mathf.Clamp(jumpDirection.x, -5f, 5f);
            jumpDirection.y = jump;
            jumpDirection.z = Mathf.Clamp(jumpDirection.z, -5f, 5f);

            anim.SetTrigger("Jump");
            rb.AddForce(jumpDirection, ForceMode.Impulse);//add force and torque
        }
    }
}