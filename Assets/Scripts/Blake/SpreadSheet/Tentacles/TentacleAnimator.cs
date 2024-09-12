using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleAnimator : MonoBehaviour
{
    private Enemy SpreadSheet;
    private Animator Anim;
    public int ThrowChance;
    // Start is called before the first frame update
    void Start()
    {
        SpreadSheet = GetComponentInParent<Enemy>();
        Anim = GetComponent<Animator>();
        StartCoroutine(Wiggle());
    }
    private void Update()
    {
        if(SpreadSheet.health <= 0)
        {
            Anim.SetTrigger("Death");
        }
    }
    public void Throw()
    {
        int chance = Random.Range(0, 100);
        if(chance <= ThrowChance)
        {
            Anim.SetTrigger("Throw");
        }
    }
    private IEnumerator Wiggle()
    {
        float Wait = Random.Range(0, 6);
        float Time = Wait/10;
        yield return new WaitForSeconds(Time);
        Anim.SetTrigger("Wiggle");
    }
}
