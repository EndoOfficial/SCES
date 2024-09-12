using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NicotineSpawner : MonoBehaviour
{
    public GameObject NicotinePrefab;

    public float WaitTime;
    public float raycastRadius = 1f;
    public LayerMask hitLayerMask;
    public LayerMask ticketsLayerMask;
    public LayerMask playerLayerMask;
    public Vector3 LeftWallPosition;
    public Vector3 RightWallPosition;
    public Vector3 TopWallPosition;
    public Vector3 BotWallPosition;
    AudioSource audioSource;
   
    private Vector3 RandomSpawnPostion => new Vector3(UnityEngine.Random.Range(LeftWallPosition.x, RightWallPosition.x), 15f, UnityEngine.Random.Range(TopWallPosition.z, BotWallPosition.z));
    public GameObject NicotinesSpawner;
    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        MrciggsBegin();
    }
    public void OnEnable()
    {
        GameEvents.LevelWin += StopSpawn;
    }
    public void OnDisable()
    {

        GameEvents.LevelWin -= StopSpawn;
    }
    void MrciggsBegin()
    {
        LeftWallPosition = new Vector3(LeftWallPosition.x, LeftWallPosition.y, LeftWallPosition.z);
        RightWallPosition = new Vector3(RightWallPosition.x, RightWallPosition.y, RightWallPosition.z);
        TopWallPosition = new Vector3(TopWallPosition.x, TopWallPosition.y, TopWallPosition.z);
        BotWallPosition = new Vector3(BotWallPosition.x, BotWallPosition.y, BotWallPosition.z);
        
        StartCoroutine(SpawnNicotine());
    }
    IEnumerator SpawnNicotine()
    {
        while (true)
        {
            //GameEvents.OnplayAudio?.Invoke(audioSource, AudioManager.ClipTags.NicotinePatchSpawn);
            yield return new WaitForSeconds(WaitTime);
            Vector3 newPosition;
            VacantRandomPosition(out newPosition);
            Instantiate(NicotinePrefab, newPosition, Quaternion.identity);
        }
    }
    private bool VacantRandomPosition(out Vector3 position)
    {
        bool overLap;
        Vector3 randomPostion;
        
        int countLimit = 500;
        do
        {
            randomPostion = RandomSpawnPostion;
            overLap = Physics.SphereCast(randomPostion, raycastRadius, Vector3.down, out RaycastHit hitInfo, 15f, hitLayerMask);
            countLimit--;
        }
        while (countLimit > 0 && !overLap );

        if (countLimit <= 0)
        {
            position = Vector3.zero;
            return false;
        }
        position = randomPostion;
        return true;
    }
    void StopSpawn()
    {
        StopAllCoroutines();
    }
}
