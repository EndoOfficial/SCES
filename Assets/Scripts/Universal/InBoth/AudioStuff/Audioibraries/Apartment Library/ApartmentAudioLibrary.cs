using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Apartment Audio Library", fileName = "Apartment Audio Library")] // This is the name of the audio library
public class ApartmentAudioLibrary : ScriptableObject
{
    public List<ApartmentAudioClip> audioClips; // list of (Apartment) sounds
}
