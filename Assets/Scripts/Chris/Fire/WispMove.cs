using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WispMove : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject player;
    public int interval;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
        agent.speed = 8;
        StartCoroutine(repeat());
    }

    private IEnumerator repeat()
    {
        while (true)
        {
            var playerpos = new Vector3(player.transform.position.x + Random.Range(-10, 10), player.transform.position.y, player.transform.position.z + Random.Range(-10, 10));
            agent.destination = playerpos;
            yield return new WaitForSecondsRealtime(interval);
        }
    }
}
