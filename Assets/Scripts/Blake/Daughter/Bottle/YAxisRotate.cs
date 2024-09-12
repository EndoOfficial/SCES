using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YAxisRotate : MonoBehaviour
{
    public Transform target;
    public float Speed;
    private void Update()
    {
        transform.RotateAround(target.transform.position, Vector3.up, Speed * Time.deltaTime);
    }
}