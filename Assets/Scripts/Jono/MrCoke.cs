using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MrCoke : MonoBehaviour
{
    public GameObject ItemSpawner;

    public float SpawnNoise;
    public new AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        StartCoroutine(GiveOrder());
        SpawnSound();
        //audio.PlayOneShot(SpawnNoise);
    }

    public IEnumerator GiveOrder()
    {
        yield return new WaitForSeconds(10);
        //Instantiate(ItemSpawner);
        ItemSpawner = GameObject.FindGameObjectWithTag("ItemSpawner");
        ItemSpawner.GetComponent<ItemSpawner>().CanSpawn = true;
        Destroy(gameObject);

    }

    public void SpawnSound()
    {
        SpawnNoise = Random.Range(1, 4);

        //GameEvents.OnCorporateplayAudio?.Invoke(GetComponent<AudioSource>(), AudioManager.CorporateClipTags.BossSpawn);
        if (SpawnNoise == 1)
        {
            GameEvents.OnCorporateplayAudio?.Invoke(GetComponent<AudioSource>(), AudioManager.CorporateClipTags.BossSpawn1);
        }
        if (SpawnNoise == 2)
        {
            GameEvents.OnCorporateplayAudio?.Invoke(GetComponent<AudioSource>(), AudioManager.CorporateClipTags.BossSpawn2);
        }
        if (SpawnNoise == 3)
        {
            GameEvents.OnCorporateplayAudio?.Invoke(GetComponent<AudioSource>(), AudioManager.CorporateClipTags.BossSpawn3);
        }
        if (SpawnNoise == 4)
        {
            GameEvents.OnCorporateplayAudio?.Invoke(GetComponent<AudioSource>(), AudioManager.CorporateClipTags.BossSpawn4);
        }
        
    }
}
