using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPills : MonoBehaviour
{
    public Transform player;
    public GameObject[] PillToSpawn;
    private int Pillnum;
    private bool Spawn = true;
    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }
    private void OnEnable()
    {
        GameEvents.OnGameOver += OnGameOver;
    }
    private void OnDisable()
    {
        GameEvents.OnGameOver -= OnGameOver;
    }
    private void OnGameOver(bool gameover)
    {
        Spawn = false;
    }
    public void StartSpawn()
    {
        if (Spawn)
        {
            Pillnum = Random.Range(0, PillToSpawn.Length);
            Instantiate(PillToSpawn[Pillnum], new Vector3(transform.position.x, 5, transform.position.z), Quaternion.identity);
        }
    }
}