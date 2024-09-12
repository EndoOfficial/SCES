using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public GameObject winStuff;

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
        /*heartObj.enabled = true; // enable the heart mesh
        mesh.enabled = true;*/

        winStuff.SetActive(true);
        //winstuff should be the child of this object and will be the things you want enabled

    }

/*    private void Start()
    {
        heartObj = GetComponent<MeshRenderer>();
        mesh = GetComponent<MeshCollider>();
    }*/

    private void Update()
    {
        transform.Rotate(0, 0, 0.5f); // makes the object rotate
    }
}
