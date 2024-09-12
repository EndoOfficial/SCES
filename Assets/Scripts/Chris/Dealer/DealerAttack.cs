using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealerAttack : MonoBehaviour
{
    public GameObject bigBill;
    public GameObject babyBill;
    public GameObject bigSpawn;
    public GameObject[] babySpawn;
    public GameObject[] deathSpawn;
    private Animator anim;
    public int chance;
    public float delay;

    protected void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(Delay());
    }

    public void Attack()
    {
        anim.ResetTrigger("NormalAttack");
        Instantiate(bigBill, bigSpawn.transform.position, bigSpawn.transform.rotation);
        StartCoroutine(Delay());
    }

    public void Flurry()
    {
        anim.ResetTrigger("Flurry");
        for (int i = 0; i < babySpawn.Length; i++)
        {
            Instantiate(babyBill, babySpawn[i].transform);
        }
        StartCoroutine(Delay());
    }

    public void Death()
    {
        for (int i = 0; i < deathSpawn.Length; i++)
        {
            Instantiate(babyBill, deathSpawn[i].transform);
        }
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSecondsRealtime(delay + Random.Range(0, 2));
        float rand = Random.Range(0, 100);
        if (rand <= chance)
        {
            anim.SetTrigger("Flurry");
        }
        else
        {
            anim.SetTrigger("NormalAttack");
        }
    }
}
