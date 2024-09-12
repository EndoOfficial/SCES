using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    public Transform camTransform; //Camera's position
    private void Start()
    {
        camTransform = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Transform>();
    }

    void Update()
    {
        transform.rotation = camTransform.rotation; // faces towards that position
    }
}

