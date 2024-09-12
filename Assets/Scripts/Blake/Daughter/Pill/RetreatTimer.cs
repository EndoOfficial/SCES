using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetreatTimer : MonoBehaviour
{
    public bool TimesUp = false;
    public bool Attack = false;
    public void ReatreatTimer()
    {
        StartCoroutine(RetreatTime());
    }
    public void AttackTimer()
    {
        Attack = true;
        StartCoroutine(AttackTime());
    }
    private IEnumerator RetreatTime()
    {
        yield return new WaitForSeconds(1f);
        TimesUp = true;
        yield return new WaitForSeconds(.1f);
        TimesUp = false;
    }
    private IEnumerator AttackTime()
    {
        yield return new WaitForSeconds(.1f);
        Attack = false;
    }
}
