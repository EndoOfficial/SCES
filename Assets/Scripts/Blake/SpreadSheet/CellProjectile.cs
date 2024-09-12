using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellProjectile : MonoBehaviour
{
    public int damage;
    public float speed;
    private GameObject player;

    private void Start()
    {
        gameObject.transform.parent = null;
        player = GameObject.Find("Player");
        transform.LookAt(player.transform);
    }

    private void Update()
    {
        transform.position += transform.forward.normalized * speed * Time.deltaTime;
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
