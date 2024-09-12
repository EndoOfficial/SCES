using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallShoot : MonoBehaviour
{
    public int damage;
    public float FireRate;
    public GameObject fireBall;
    public bool _paused;

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

    public void ShootStart()
    {
        StartCoroutine(Shoot());
    }

    public void ShootStop()
    {
        StopAllCoroutines();
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            if (!_paused)
            {
                yield return new WaitForSecondsRealtime(FireRate);
                var obj = Instantiate(fireBall, transform.position, transform.rotation);
                obj.GetComponent<FireBallProjectile>().damage = damage;
            }
            yield return new WaitForSecondsRealtime(FireRate);
        }
    }
}
