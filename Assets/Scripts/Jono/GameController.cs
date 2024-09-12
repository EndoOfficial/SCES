using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float KillCount;
    public float ItemsCollected;
    public float GameWinCollectCount;
    public float KillsToSpawn;

    public GameObject MrConcaine;
    public GameObject itemSpawner;
    public Transform CocaineSpawn;

    public List<GameObject> CokeSpawns;
    public float FacelessSpawnSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(KillCount >= KillsToSpawn && itemSpawner.GetComponent<ItemSpawner>().ItemsToSpawn.Count > 0)
        {
            KillCount = 0;
            
                StartCoroutine(SpawnCokeMan());         

            
            
        }
        if(ItemsCollected >= GameWinCollectCount)
        {
            GameEvents.LevelWin?.Invoke();
        }
        
    }

    public IEnumerator SpawnCokeMan()
    {
        float NearestDist = 0;
        GameObject NearestSP = null;

        //Looks throgh all values of SpawnPoint in CokeSpawns
        foreach(GameObject SpawnPoint in CokeSpawns)
        {
            //Gets the player distance value from the player dist script of each object in list
            var PlayDist = SpawnPoint.GetComponent<GetDistToPlayer>();

            if(PlayDist != null)
            {
                float dist = PlayDist.PlayerDist;

                //Checks if the nearest object is 0 or is less thn the distance fo the last object
                if(NearestDist == 0 || dist < NearestDist)
                {
                    //sets the approiate variables once the closest point has been found.
                    NearestDist = dist;
                    NearestSP = SpawnPoint;                    
                }
            }
            //float Dist 
        }

        //Spawns prefab at the closest point found
        Instantiate(MrConcaine, NearestSP.transform);
        yield return null;
    }
}
