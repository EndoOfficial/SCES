using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallProjectile : MonoBehaviour
{
    public int damage;
    public float speed;
    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
        transform.LookAt(player.transform);
        Destroy(gameObject, 5);
    }

    private void Update()
    {
        transform.position += transform.forward.normalized * speed * Time.deltaTime;
        transform.position += (player. transform.position - transform.position) * .5f * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameEvents.DamagePlayer?.Invoke(damage);
            Destroy(gameObject);
        }
    }
}
