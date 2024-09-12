using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuffPatchChecker : MonoBehaviour
{
    public GameObject CokeChecker;
    public bool Pursue;

    private void Start()
    {
        CokeChecker = GameObject.Find("CocaineCheck");
    }
    void Update()
    {
        if (CokeChecker.GetComponent<CokeCheck>().allPuffed)
        {
            Pursue = true;
        }
        else
        {
            Pursue = false;
        }
    }
}
