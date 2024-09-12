using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCycle : MonoBehaviour
{
    public GameObject[] TextToCycle; // all the text (needs to be put in order)
    private int Cycle; // current text displayed
    public float CycleDelay; // wait time
    void Start()
    {
        Cycle = TextToCycle.Length - 1; // automatically sets the array
        StartCoroutine(StartCycle());
    }
    private IEnumerator StartCycle()
    {
        for (int i = 0; i < Cycle;)
        {
            yield return new WaitForSeconds(CycleDelay);
            TextToCycle[i].SetActive(false); // disables current text
            i++; // counts up by one
            TextToCycle[i].SetActive(true); // enables the current text

            if (i >= Cycle) // once 'i' gets to the end of the array
            {
                yield return new WaitForSeconds(CycleDelay); // wait again
                TextToCycle[i].SetActive(false); // disables current text
                i = 0; // resets count to 0
                TextToCycle[i].SetActive(true); // enables the current text
            }
        }
    }
}
