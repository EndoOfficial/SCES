using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int damage = 10;
    public Camera fpsCam;
    public ParticleSystem muzzelFlash;
    public float impactForce = 30f;
    public float fireRate= 15f;
    private float nextTimeToFire = 0;

    public void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }
    void Shoot()
    {
        muzzelFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            Debug.Log("damage" + hit);
            Enemy target = hit.transform.GetComponent<Enemy>();
            Debug.Log(target);

            if (target != null)
            {
                GameEvents.DamageEnemy?.Invoke(damage, hit.transform.gameObject);
            }
        }
    }
}

