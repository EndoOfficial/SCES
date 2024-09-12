using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellSpawner : MonoBehaviour
{
    public GameObject[] CellSpawnPoints;
    public GameObject DealDamageCell;
    public GameObject TakeDamageCell;
    public GameObject CellTarget;
    private int CellLocation;
    public int SpawnLimit;
    public int SpawnDealChance;
    public bool State2;
    public bool State3;
    void Start()
    {
        CellSpawnPoints = GameObject.FindGameObjectsWithTag("SpawnLocation");
        // gets all the spawn locations once
        StartCoroutine(Spawn());
    }
    private void OnEnable()
    {
        GameEvents.CellsShot += Respawn;
        // when a cell is shot
    }

    private void OnDisable()
    {
        GameEvents.CellsShot -= Respawn;
        // when a cell is shot
    }
    void Respawn()
    {
        StopAllCoroutines();
        // to ensure the coroutines don't double up
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(0.25f);
        // waits before spawning, to ensure all spawnpoints are available
        for (int i = 0; i < SpawnLimit; i++)
        {
            int SpawnTake = Random.Range(0, 100);
            // chance to spawn the cells that deal damage to the boss vs player

            CellLocation = Random.Range(0, CellSpawnPoints.Length);
            CellTarget = CellSpawnPoints[CellLocation];
            // selects a random spawn point

            if (CellSpawnPoints[CellLocation].tag != ("SpawnLocation"))
            {
                i--;
                //  if it can't spawn there the counter doesn't go up to
                // ensure that there will always be the set amount spawned
            }
            else
            {
                if (SpawnTake < SpawnDealChance)
                {
                    Instantiate(DealDamageCell, CellTarget.transform);
                }
                else
                {
                    Instantiate(TakeDamageCell, CellTarget.transform);
                }
                // chance to spawn the cells that deal damage to the boss vs player

                yield return new WaitForSeconds(0.02f);
                // ensures that the cells have time to spawn so they can't overlap
            }
        }
    }
}

