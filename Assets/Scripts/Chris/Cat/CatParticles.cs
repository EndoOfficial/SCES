using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatParticles : MonoBehaviour
{
    private ParticleSystem particles;
    private Rigidbody rb;

    private void Start()
    {
        particles = GetComponent<ParticleSystem>();
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Ground") && rb.velocity.y <= 0)
        {
            particles.Play();
        }   
    }
}
