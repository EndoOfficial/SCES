using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 2;
    // Update is called once per frame

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);



    }       

}
