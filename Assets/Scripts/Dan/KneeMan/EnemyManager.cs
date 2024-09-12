using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject EnemyPrefab;

    public float WaitTime;
    public List<GameObject> Doors;
    public int numEnemies;
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }
    IEnumerator SpawnEnemies()
    {
        int Loops = 0;
        for (int i = 0; i < numEnemies; i++)
        {
            Loops++;
            if (Loops > numEnemies)
            {
                StopAllCoroutines();
            }

            if (i >= Doors.Count)
            {
                i = 0;
            }
            // The above makes it so that the enemies re-use doors to spawn
            // but still only spawn the amount set by numEnemies
            yield return new WaitForSeconds(WaitTime);
            Instantiate(EnemyPrefab,new Vector3(Doors[i].transform.position.x, Doors[i].transform.position.y + .3f, Doors[i].transform.position.z), Quaternion.identity);
        }
    }
}