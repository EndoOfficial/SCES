using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CokeCheck : MonoBehaviour
{
    public bool allPuffed;
    public int CocainePuffs;
    void Start()
    {
        CocainePuffs = GameObject.FindGameObjectsWithTag("CocainePuff").Length;
        StartCoroutine(Checker());
    }
    private IEnumerator Checker()
    {
        CocainePuffs = GameObject.FindGameObjectsWithTag("CocainePuff").Length; // reasigns all the puff patches
        if (CocainePuffs == 0) // if there are none
        {
            allPuffed = true;
        }
        if(CocainePuffs > 0) // if there's at least one
        {
            allPuffed = false;
        }
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(Checker());
    }
}
