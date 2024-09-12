using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityDamage : MonoBehaviour
{
    private GameObject player;
    public float distance;
    private bool toggle;
    public int damage;
    private float tempDamage;
    private bool _paused;

    private void OnEnable()
    {
        GameEvents.OnPauseGame += OnPauseGame;
    }

    private void OnDisable()
    {
        GameEvents.OnPauseGame -= OnPauseGame;
    }

    private void OnPauseGame(bool paused)
    {
        _paused = paused;   
    }

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= distance && toggle) // is close enough
        {
            toggle = false;
            StartCoroutine(Constant());
        }
        else if (Vector3.Distance(transform.position, player.transform.position) >= distance)
        {
            toggle = true;
            StopAllCoroutines();
        }
    }

    private IEnumerator Constant()
    {
        while (true)
        {
            while (!_paused)
            {
                var dist = (Vector3.Distance(transform.position, player.transform.position) + 1); // set dam to destance converted to an int
                tempDamage = dist / distance;
                tempDamage = 1 - tempDamage;
                tempDamage = Mathf.Clamp(tempDamage, 0, float.PositiveInfinity);
                var dam = tempDamage * damage;
                GameEvents.DamagePlayer?.Invoke((int)dam + 1);
                yield return new WaitForSecondsRealtime(1);
            }
            yield return new WaitForSecondsRealtime(1);
        }
    }
}
