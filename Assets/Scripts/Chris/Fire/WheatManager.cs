using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheatManager : MonoBehaviour
{
    public float timer;
    private void OnEnable()
    {
        GameEvents.WheatRespawn += WheatRespawn;
    }
    private void OnDisable()
    {
        GameEvents.WheatRespawn += WheatRespawn;
    }

    private void WheatRespawn(GameObject obj)
    {
        StartCoroutine(Timer(obj));
    }

    private IEnumerator Timer(GameObject obj)
    {
        yield return new WaitForSecondsRealtime(timer);
        obj.SetActive(true);
    }
}
