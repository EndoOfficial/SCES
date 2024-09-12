using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectWheat : MonoBehaviour
{
    public Vector3 closestWheatPatch;
    public int interval;
    public bool inWheat;
    private GameObject player;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Wheat"))
        {
            other.gameObject.SetActive(false);
            GameEvents.WheatRespawn?.Invoke(other.gameObject);
            inWheat = true;
        }
    }
    private void Start()
    {
        player = GameObject.Find("Player");
    }

    public void FindWheat()
    {
        StartCoroutine(Repeat());
    }

    private IEnumerator Repeat()
    {
        while (true)
        {
            float dist = float.PositiveInfinity;
            GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("Wheat");

            foreach (var obj in taggedObjects)
            {
                var d = (transform.position - obj.transform.position).sqrMagnitude;
                if (d < dist)
                {
                    closestWheatPatch = obj.transform.position;
                    dist = d;
                }
            }
            if(taggedObjects.Length == 0)
            {
                var playerpos = new Vector3(player.transform.position.x + Random.Range(-10,10), player.transform.position.y, player.transform.position.z + Random.Range(-10, 10));
                closestWheatPatch = playerpos;
            }
            yield return new WaitForSeconds(interval);
        }
    }
}
