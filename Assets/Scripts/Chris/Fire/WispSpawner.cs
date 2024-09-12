using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WispSpawner : MonoBehaviour
{
    public GameObject wisp;
    public bool _paused;

    private void OnEnable()
    {
        GameEvents.OnPauseGame += OnPauseGame;
    }

    private void OnDisable()
    {
        GameEvents.OnPauseGame -= OnPauseGame;
    }

    private void OnPauseGame(bool paused)
    {
        _paused = paused;
    }

    public void startSpawn()
    {
        StartCoroutine(SpawnWisp());
    }

    public void stopSpawn()
    {
        StopCoroutine(SpawnWisp());
    }

    private IEnumerator SpawnWisp()
    {
        while (true)
        {
            while (!_paused)
            {
                yield return new WaitForSecondsRealtime(.5f);
                var obj = Instantiate(wisp, transform.position, Quaternion.identity);
                obj.transform.localScale = new Vector3(1, 1, 1);
            }
            yield return new WaitForSecondsRealtime(.5f);
        }
    }
}
