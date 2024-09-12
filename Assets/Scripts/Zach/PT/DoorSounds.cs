using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoorSounds : MonoBehaviour
{
    private AudioSource source;
    private void OnEnable()
    {

        GameEvents.DoorOpen += DoorOpen;
        GameEvents.DoorClose += DoorClose;
    }
    private void OnDisable()
    {
        GameEvents.DoorOpen -= DoorOpen;
        GameEvents.DoorClose -= DoorClose;
    }
    private void Start()
    {
        source = GetComponent<AudioSource>();    
    }
    void DoorClose()
    {
        GameEvents.OnRuralplayAudio?.Invoke(source, AudioManager.RuralClipTags.DoorSlam);
    }
    void DoorOpen()
    {
        GameEvents.OnRuralplayAudio?.Invoke(source, AudioManager.RuralClipTags.DoorCreak);
    }

}
