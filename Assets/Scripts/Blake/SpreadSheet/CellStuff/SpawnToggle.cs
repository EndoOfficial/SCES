using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnToggle : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        tag = ("Untagged");
    }
}
