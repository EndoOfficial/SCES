using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public GameObject player;
    protected Animator anim;
    protected GameObject cam;

    protected bool canSeePlayerRay;
    protected bool shootAtPlayerRay;
    public bool seePlayer;
    protected Vector3 playerDirection;
    protected Vector3 OldPlayerDirection;
    protected Vector3 bulletDirection;
    public float bulletSpread;
    public float maxSpread;
    protected float tempSpread;
    public float attackSpeed;
    public int damage;
    public float delay;
    public bool Paused;

    public GameObject bulletSpawn;
    public TrailRenderer bulletTrail;
    public GameObject bulletHit;

    private void Start()
    {
        player = GameObject.Find("Player");
        cam = player.transform.Find("Head").transform.Find("Camera").gameObject;
        anim = GetComponent<Animator>();
        tempSpread = bulletSpread;
        StartCoroutine(Position());
    }

    private void OnEnable()
    {
        GameEvents.OnPauseGame += PauseGame;
    }
    private void OnDisable()
    {
        GameEvents.OnPauseGame -= PauseGame;
    }

    void PauseGame(bool paused)
    {
        Paused = paused;
    }
    private void FixedUpdate()
    {
        //gets player direction

        playerDirection = cam.transform.position - transform.position;

        //playerDirection = playerDirection;

        //if enemy can see player
        if (canSeePlayerRay = Physics.Raycast(transform.position, playerDirection, out RaycastHit hitinfo))
        {
            if (hitinfo.transform.CompareTag("Player") && !seePlayer)
            {
                seePlayer = true;
                StartCoroutine(Attack());
            }
            else if (!hitinfo.transform.CompareTag("Player") && seePlayer)
            {
                seePlayer = false;
                bulletSpread = tempSpread;
            }
        }
    }

    protected virtual IEnumerator Attack()
    {
        yield return new WaitForSeconds(1);
        anim.SetTrigger("Shoot");
    }

    //shoot coroutine
    protected virtual IEnumerator Shoot()
    {
        if (seePlayer && !Paused)
        {
            //randomizes bulletSpread
            float temp = Random.Range(-bulletSpread, bulletSpread);
            float temp1 = Random.Range(-bulletSpread, bulletSpread);
            float temp2 = Random.Range(-bulletSpread, bulletSpread);

            //get the normalized playerDirection
            bulletDirection = OldPlayerDirection.normalized;
            //applies the random bulletspread to the bullet direction
            bulletDirection = new Vector3(
                bulletDirection.x + temp,
                bulletDirection.y + temp1,
                bulletDirection.z + temp2);

            //if the ray hits the player
            if (shootAtPlayerRay = Physics.Raycast(transform.position, bulletDirection, out RaycastHit hit))
            {

                TrailRenderer trail = Instantiate(bulletTrail, bulletSpawn.transform.position, Quaternion.identity);
                StartCoroutine(SpawnTrail(trail, hit));
                //if (hit.transform.CompareTag("Player"))
                //{
                //    GameEvents.DamagePlayer?.Invoke(damage);
                //}
            }
            //increases spread every shot
            if (bulletSpread <= maxSpread)
            {
                bulletSpread += 0.01f;
            }
        }
        yield return new WaitForSecondsRealtime(attackSpeed);
        anim.SetTrigger("Shoot");
    }

    protected IEnumerator SpawnTrail(TrailRenderer trail, RaycastHit hit)
    {
        float time = 0;
        Vector3 startposition = trail.transform.position;

        while (time < 3)
        {
            trail.transform.position = Vector3.Lerp(startposition, hit.point, time);
            time += Time.deltaTime / trail.time;

            yield return null;
        }
        trail.transform.position = hit.point;
        if (hit.transform.CompareTag("Player"))
        {
            //damage enemy Event
            GameEvents.DamagePlayer?.Invoke(damage); //This passes though a damage and the object that GET'S HIT
            //GameEvent to show damage

            WeakPoints target = hit.transform.GetComponent<WeakPoints>();
            if (target != null)
            {
                GameEvents.DamagePlayer?.Invoke(damage);
                target.Shot();
            }
        }
        else
        {
            Instantiate(bulletHit, hit.point + (hit.normal * .01f), Quaternion.FromToRotation(Vector3.forward, hit.normal));
        }
        Destroy(trail.gameObject, trail.time);
    }

    public IEnumerator Position()
    {
        yield return new WaitForSecondsRealtime(delay);
        OldPlayerDirection = playerDirection;
        StartCoroutine(Position());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, bulletDirection);
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, playerDirection);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, OldPlayerDirection);
    }
}
