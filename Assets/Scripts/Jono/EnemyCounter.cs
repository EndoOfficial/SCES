using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    public bool Spawning;
    public int Enemy;
    void Start()
    {
        Enemy = GameObject.FindGameObjectsWithTag("Enemy").Length;
        StartCoroutine(Checker());
    }

    private IEnumerator Checker()
    {
        Enemy = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if ( Enemy <= 0)
        {
            GameEvents.LevelWin?.Invoke();
        }
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(Checker());
    }
}
