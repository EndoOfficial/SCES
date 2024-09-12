using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public List<Transform> SpawnPoints = new List<Transform>();
    public List<GameObject> ItemsToSpawn = new List<GameObject>();

    public bool CanSpawn;
    public GameObject ItemToSpawn;
    public Transform SpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CanSpawn)
        {
            StartCoroutine(SpawnItem());
        }
    }

    public IEnumerator SpawnItem()
    {
        CanSpawn = false;
        ItemToSpawn = ItemsToSpawn[Random.Range(0, ItemsToSpawn.Count)];
        SpawnPoint = SpawnPoints[Random.Range(0, SpawnPoints.Count)];
        Instantiate(ItemToSpawn, SpawnPoint);
        ItemsToSpawn.Remove(ItemToSpawn);
        yield return new WaitForSeconds(20);
        
    }
}
