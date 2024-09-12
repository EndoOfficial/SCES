using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunSyringe : EnemyGun
{
    public float PositionDelay;
    public GroundCheck grounded;

    //shoot coroutine
    protected override IEnumerator Shoot()
    {
        if (!grounded.Grounded && seePlayer && !Paused)
        {
            GameEvents.OnSlumsplayAudio?.Invoke(GetComponent<AudioSource>(), AudioManager.SlumsClipTags.NeedleShoot);

            //randomizes bulletSpread
            float temp = Random.Range(-bulletSpread, bulletSpread);
            float temp1 = Random.Range(-bulletSpread, bulletSpread);
            float temp2 = Random.Range(-bulletSpread, bulletSpread);

            //get the normalized playerDirection
            bulletDirection = OldPlayerDirection;
            //applies the random bulletspread to the bullet direction
            bulletDirection = new Vector3(
                bulletDirection.x + temp,
                bulletDirection.y + temp1,
                bulletDirection.z + temp2);

            //if the ray hits the player
            if (shootAtPlayerRay = Physics.Raycast(transform.position, bulletDirection, out RaycastHit hit))
            {
                //anim.SetTrigger("Shoot");
                TrailRenderer trail = Instantiate(bulletTrail, transform.position, Quaternion.identity);
                base.StartCoroutine(SpawnTrail(trail, hit));
            }
            //increases spread every shot
            if (bulletSpread <= maxSpread)
            {
                bulletSpread += 0.01f;
            }
        }
        yield return new WaitForSecondsRealtime(attackSpeed);
    }
}
