using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject Paper;
    public float spawnTime;
    private Vector3 origin;
    public float radius = 5;

    void Start()
    {
        origin = transform.position;
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        Vector3 randomPosition = origin + Random.insideUnitSphere * radius;
        Instantiate(Paper, randomPosition, Quaternion.identity);
    }

}
