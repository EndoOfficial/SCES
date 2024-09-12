using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    public float speed;
    private bool active = false;

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
        active = true;
    }

    private void FixedUpdate()
    {
        if (!active) // stops the platforms when you Win the level
        {
            transform.Translate(new Vector3(0, 0, 1) * speed * Time.deltaTime);
        }
    }
}
