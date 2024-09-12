using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetect : MonoBehaviour
{
    public bool range; 
    public float distance;
    public GameObject player;
    private void Start()
    {
        player = GameObject.Find("Player");
        StartCoroutine(Repeat());
    }

    private IEnumerator Repeat()
    {
        while (true)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < distance)
            {
                range = true;
            }
            else range = false;
            yield return new WaitForSeconds(1);
        }
    }
}
