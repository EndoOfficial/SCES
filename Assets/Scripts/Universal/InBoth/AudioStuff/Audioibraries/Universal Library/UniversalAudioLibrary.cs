using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Universal Audio Library", fileName = "Universal Audio Library")] // This is the name of the audio library
public class UniversalAudioLibrary : ScriptableObject
{
    public List<UniversalAudioClip> audioClips; // list of (Universal) sounds
}
