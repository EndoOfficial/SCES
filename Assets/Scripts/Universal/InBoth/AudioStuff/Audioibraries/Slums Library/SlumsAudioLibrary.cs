using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Slums Audio Library", fileName = "Slums Audio Library")] // This is the name of the audio library
public class SlumsAudioLibrary : ScriptableObject
{
    public List<SlumsAudioClip> audioClips; // list of (Slums) sounds
}
