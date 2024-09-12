using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayer : MonoBehaviour
{
    public LayerMask Player;
    public float PosX;
    public float PosY;
    public float PosZ;
    public float radius;
    public int damage;
    public float cooldown;

    public bool Attacked = false;
    public bool hit;
    void Update()
    {
        if (Physics.CheckSphere(new Vector3(transform.position.x + PosX, transform.position.y + PosY, transform.position.z + PosZ), radius, Player))
        {
            if (!hit)
            {
                hit = true;
                Attacked = true;
                StartCoroutine(AttackedDelay());
                GameEvents.DamagePlayer?.Invoke(damage);
                StartCoroutine(HitDelay());
            }
        }
        
    }
    private IEnumerator HitDelay()
    {
        yield return new WaitForSeconds(cooldown);
        hit = false;
    }
    private IEnumerator AttackedDelay()
    {
        yield return new WaitForSeconds(.1f);
        Attacked = false;
    }
}
