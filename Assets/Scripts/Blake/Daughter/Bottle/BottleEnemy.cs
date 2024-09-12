using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleEnemy : Enemy
{
    // Inherits from enemy so I do not have to retype everything in the enemy script into here
    // whilst having it's own functions that do not affect the original script in any way 
    public GameObject[] pill;
    private int Pillnum;
    public float spawnlimit;
    private float randomizer;
    public AudioSource Source;
    private void Explosion()
    {
        StartCoroutine(Explode());
    }
    private void PlayDeath()
    {
        Source = GetComponent<AudioSource>();
        GameEvents.OnApartmentplayAudio?.Invoke(Source, AudioManager.ApartmentClipTags.PillBottleDeath);
    }
    private IEnumerator Explode()
    {
        for (int i = 0; i < spawnlimit;)
        {
            randomizer = Random.Range(-1, 1); // gets a random number from -1 to 1
            Pillnum = Random.Range(0, pill.Length); // chooses a rondom pill
            Instantiate(pill[Pillnum], new Vector3(transform.position.x + randomizer, 3 + randomizer, transform.position.z + randomizer), Quaternion.identity);
            // spawns the random pill just above the bottle, with some slight variation to it's spawn location as to make the pills fly in random directions
            i++;
        }
        // once done

        GameEvents.BottleCount?.Invoke(); // counts the bottles deaths for all pill death
        Destroy(gameObject);
        yield return null;
    }
}
