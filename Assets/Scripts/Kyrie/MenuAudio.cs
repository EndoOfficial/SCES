using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuAudio : MonoBehaviour
{
    public AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void MenuButtonClick()
    {
        GameEvents.OnUniversalplayAudio?.Invoke(audioSource, AudioManager.UniversalClipTags.MenuClick);
    }

    public void MenuButtonOver()
    {
        GameEvents.OnUniversalplayAudio?.Invoke(audioSource, AudioManager.UniversalClipTags.MenuOver);
    }
}