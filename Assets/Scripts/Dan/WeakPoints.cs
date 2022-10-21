using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPoints : MonoBehaviour
{
    public bool leftShot;
    public bool rightShot;
    public bool headShot;
    public HeadShot Head;

    private void OnEnable()
    {
        GameEvents.DamageEnemy += Shot;
    }

    private void OnDisable()
    {
        GameEvents.DamageEnemy -= Shot;

    }

    private void Start()
    {
        Head = Head.GetComponent<HeadShot>();
        leftShot = false;
        rightShot = false;
        headShot = false;

    }

    public void Shot(int damage, GameObject Enemy)
    {
        if (CompareTag("LeftKnee"))
        {
            leftShot = true;
            gameObject.SetActive(false);
        }

        if (CompareTag("RightKnee"))
        {
            rightShot = true;
            gameObject.SetActive(false);
        }

        if  (Head.head && CompareTag("Head"))
        {
            headShot = true;
        }

    }
    public void Recover()
    {
        leftShot = false;
        rightShot = false;
        headShot = false;
        gameObject.SetActive(true);
    }
}