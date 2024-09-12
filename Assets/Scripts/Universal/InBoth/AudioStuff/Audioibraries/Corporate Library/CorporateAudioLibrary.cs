using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Corporate Audio Library", fileName = "Corporate Audio Library")] // This is the name of the audio library
public class CorporateAudioLibrary : ScriptableObject
{
    public List<CorporateAudioClip> audioClips; // list of (Corpo) sounds
}
