using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PTDoorCloser : MonoBehaviour
{

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("C");
        GameEvents.DoorClose?.Invoke();
        
    }
}
