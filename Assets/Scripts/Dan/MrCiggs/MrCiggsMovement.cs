using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MrCiggsMovement : MonoBehaviour
{
    public GameObject Move1;
    public GameObject Move2;
    private Vector3 Move3;
    private float time;
    public float speed;

    private void Start()
    {
        move();
    }

    private void move()
    {
        Move3 = new Vector3(transform.position.x, transform.position.y, Random.Range(Move1.transform.position.z, Move2.transform.position.z));
        time = Move3.magnitude;
        StartCoroutine(timer());
        LeanTween.move(gameObject, Move3, time/speed);
    }

    private IEnumerator timer()
    {
        yield return new WaitForSecondsRealtime(time/speed);
        move();
    }
}
