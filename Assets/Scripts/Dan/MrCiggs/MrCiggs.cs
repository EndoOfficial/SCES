using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//-------------------------------------------------------
// I've commented out the code that was causing issues and
// placed in code that works more effectively
// Love, Blake
//-------------------------------------------------------
public class MrCiggs : MonoBehaviour
{
    //    public Transform target;
    //    public float range = 100f;

    public Transform Player;
    public Vector3 Target;
    //public ParticleSystem muzzelflashBoss;
    public int damage = 1;
    public float rage;
    public float RageRate = 1f;

    private void Start()
    {
        //    StartCoroutine(Aiming());
    }
    private void OnEnable()
    {
        GameEvents.Nicotine += DecreaseRage;
    }
    private void OnDisable()
    {
        GameEvents.Nicotine -= DecreaseRage;
    }

    //    public void Update()
    //    {
    //        Vector3 direction = target.transform.position - transform.position;
    //        Quaternion rotation = Quaternion.LookRotation(direction);
    //        transform.rotation = rotation;
    //    }
    public void Update()
    {
        Raging();
    }

    //    public void Shoot()
    //    {
    //        Debug.Log("isShooting");
    //        muzzelflashBoss.Play();

    //        RaycastHit hit;
    //        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
    //        {
    //            if (target != null)
    //            {
    //
    //            }
    //        }
    //    }
    //public void Shoot()
    //{
    //    muzzelflashBoss.Play();

    //    RaycastHit hit;
    //    Debug.Log("Fire");
    //    if (Physics.Raycast(transform.position, Target, out hit))
    //    {
    //        if (hit.transform.CompareTag("Player"))
    //        {
    //            GameEvents.DamagePlayer?.Invoke(damage);
    //            Debug.Log("Damage");
    //        }
    //    }
    //}
    public void Raging()
    {
        //FindObjectOfType<AudioManager>().Play("Rage");
        rage += RageRate * Time.deltaTime;
        GameEvents.RageIncrease?.Invoke(rage);
        if (rage >= 100)
        {
            RageRate = 0f;
        }
        else
        {
            RageRate = 5f;
        }
    }
    public void DecreaseRage()
    {
        rage -= 15f;
    }

    //  Gizmos.DrawLine(transform.position, transform.forward);
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawLine(transform.position, Player.position);
    //}
    //private IEnumerator Aiming() 
    //    // This puts a slight delay on getting the players position, meaning that if the player is running alongside the shooter the shooter will be shooting slightly behind
    //{
    //    yield return new WaitForSeconds(0.3f);
    //    Target = Player.position - transform.position;
    //    StartCoroutine(Aiming());
    //}
}