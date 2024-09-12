using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    bool isin = true;
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            bool isin = true;
            //Call event to loose health
        }
            

    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            bool isin = false;
            //Call Event to take health
        }


    }


}
