using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTimer : MonoBehaviour
{
    public int time;
    public int interval;
    public int changeTime;
    public bool timeDone;
    private bool _paused;

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

    public void StartTimer()
    {
        time = 0;
        StartCoroutine(Timer());
    }

    public void StopTimer()
    {
        time = 0;
        StopAllCoroutines();
    }

    private IEnumerator Timer()
    {
        while (time <= changeTime)
        {
            yield return new WaitForSecondsRealtime(interval);
            if (!_paused)
            {
                time++;
            }
        }
        timeDone = true;
    }
}
