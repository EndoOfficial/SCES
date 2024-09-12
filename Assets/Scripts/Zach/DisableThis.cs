using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableThis : MonoBehaviour
{
    public GameObject disablee;
    public Collider disableeCollider;
    private AudioSource source;
    private void Start()
    {
        this.source = GetComponent<AudioSource>();

    }
    private void OnTriggerEnter(Collider other)
    {
        GameEvents.OnRuralplayAudio?.Invoke(source, AudioManager.RuralClipTags.Moo);
        disablee.SetActive(false);
        disableeCollider.enabled = false;
    }
}
