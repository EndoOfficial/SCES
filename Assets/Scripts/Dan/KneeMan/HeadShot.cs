using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HeadShot : MonoBehaviour
{
    public WeakPoints LeftKnee;
    public WeakPoints RightKnee;
    public WeakPoints Head;
    public bool left;
    public bool right;
    public bool head;

    private void Start()
    {
        Head = GetComponent<WeakPoints>();
        left = false;
        right = false;
        head = false;
    }
    public void Update()
    {
        if (left)
        {
            StartCoroutine(Left());
        }

        if (right)
        {
            StartCoroutine(Right());
        }

        if (left && right )
        {
            HeadShotOpen();
        }

        if (head && Head.headShot)
        {
            Murked();
        }
    }
    public void HeadShotOpen()
    {
        left = false;
        right = false;
        StopAllCoroutines();
        head = true;
        StartCoroutine(GetUp());

    }
    private IEnumerator GetUp()
    {
        yield return new WaitForSeconds(7f);
        head = false;
        LeftKnee.Recover();
        RightKnee.Recover();
    }

    private IEnumerator Left()
    {
        yield return new WaitForSeconds(4f);
        left = false;
        LeftKnee.Recover();
    }

    private IEnumerator Right()
    {
        yield return new WaitForSeconds(4f);
        right = false;
        RightKnee.Recover();
    }

    public void Murked()
    {
        GetComponentInParent<Animator>().SetTrigger("Death");
    }
}