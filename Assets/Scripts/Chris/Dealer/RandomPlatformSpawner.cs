using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlatformSpawner : MonoBehaviour
{
    public GameObject Paper;
    public float spawnTime = 1f;
    private Vector3 origin;
    public float radius = 5;
    public float height;

    private void OnEnable()
    {
        GameEvents.LevelWin += LevelWin;
    }

    private void OnDisable()
    {
        GameEvents.LevelWin -= LevelWin;

    }

    private void LevelWin()
    {
        CancelInvoke("Spawn");
    }

    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
        origin = transform.position;
    }

    void Spawn()
    {
        Vector3 randomPosition = new Vector3(origin.x + Random.Range(-radius, radius), origin.y + Random.Range(-height, height), origin.z);
        Instantiate(Paper, randomPosition, Quaternion.identity);
    }

}