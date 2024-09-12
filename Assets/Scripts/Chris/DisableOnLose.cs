using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnLose : MonoBehaviour
{
    private void OnEnable()
    {
        GameEvents.OnGameOver += OnGameOver;
    }
    private void OnDisable()
    {
        GameEvents.OnGameOver -= OnGameOver;
    }

    private void OnGameOver(bool gameover)
    {
        gameObject.SetActive(false);
    }
}
