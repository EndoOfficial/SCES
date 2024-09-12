using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate2 : MonoBehaviour
{
    public GameObject target;
    private void Update()
    {
        transform.RotateAround(target.transform.position, Vector3.down, 20 * Time.deltaTime);
    }
}

