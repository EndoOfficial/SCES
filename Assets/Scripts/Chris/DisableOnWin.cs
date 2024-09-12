using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnWin : MonoBehaviour
{
    private void OnEnable()
    {
        GameEvents.LevelWin += LevelWin;
    }
    private void OnDisable()
    {
        GameEvents.LevelWin -= LevelWin;
    }
    private void LevelWin()
    {
        gameObject.SetActive(false);
    }
}