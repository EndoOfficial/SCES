using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletImpact : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Repeat());
    }

    private IEnumerator Repeat()
    {
        yield return new WaitForSecondsRealtime(10);
        Destroy(gameObject);
    }
}
