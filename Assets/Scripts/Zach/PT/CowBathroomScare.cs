using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowBathroomScare : MonoBehaviour
{
    public Transform endPoint;
    private float scareTime = 1;
    public GameObject Cow;
    public GameObject door;
    private AudioSource source;
    private Collider thisTrigger;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        thisTrigger = GetComponent<Collider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        GameEvents.OnRuralplayAudio?.Invoke(source, AudioManager.RuralClipTags.Moo);
        LeanTween.move(Cow, endPoint, scareTime)
            .setEaseInOutQuart()
            .setOnComplete(() =>
            {
                //slam door
                LeanTween.rotateAround(door, Vector3.up, -20, 0.5f);
                //play audio
                GameEvents.OnRuralplayAudio?.Invoke(source, AudioManager.RuralClipTags.DoorSlam);
                Cow.SetActive(false);
                thisTrigger.enabled = false;
            });
    }

}
