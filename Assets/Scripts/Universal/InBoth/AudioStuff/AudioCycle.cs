using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCycle : MonoBehaviour
{
    public List<AudioSource> audioSources = new();
    private int currentIndex = -1;

    public AudioSource GetNextAudioSource()
    {
        currentIndex++;
        if (currentIndex > audioSources.Count - 1)
            currentIndex = 0;
        //Debug.Log($"Current Index {currentIndex} {audioSources.Count}");
        return audioSources[currentIndex];
    }

    public void SetVolume(float volume)
    {
        foreach (AudioSource source in audioSources)
        {
            source.volume = volume;
        }
    }
}
