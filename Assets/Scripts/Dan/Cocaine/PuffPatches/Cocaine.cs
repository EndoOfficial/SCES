using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Cocaine : MonoBehaviour
{
    public float Cooldown;
    public LayerMask Player;
    public float radius;
    public int damage;
    public bool hit;
    public ParticleSystem cokeParticle;
    public bool particleActivated = false;
    private Animator animator;

    private void Start()
    {
        //animator = GetComponent<Animator>();
         
    }
    private void OnTriggerEnter(Collider other)
    {

        
        if (other.gameObject.CompareTag("Enemy"))
        {
           var mrCoke= other.gameObject.GetComponent<Mrcoke2>();

            //if (mrCoke !=null&& mrCoke.target==this.gameObject)
            //{
                Debug.Log("Particle activated");
                particleActivated = true;
                cokeParticle.Play();
                //animator.SetTrigger("Puff");
                
            //}
           
            
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && particleActivated)
        {
            
            if (Physics.CheckSphere(transform.position, radius, Player))
            {
                if (!hit)
                {
                    hit = true;
                    StartCoroutine(HitDelay());
                    GameEvents.DamagePlayer?.Invoke(damage);
                }
            }
        }
    }
    private IEnumerator HitDelay()
    {
        yield return new WaitForSeconds(Cooldown);
        hit = false;
    }
}

    
