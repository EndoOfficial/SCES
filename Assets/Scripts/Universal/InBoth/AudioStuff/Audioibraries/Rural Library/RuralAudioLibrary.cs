using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// gets all the clips and makes a library to use afterwards in the audiomanager

[CreateAssetMenu(menuName = "Rural Audio Library", fileName = "Rural Audio Library")] // This is the name of the audio library
public class RuralAudioLibrary : ScriptableObject
{
    public List<RuralAudioClip> audioClips; // list of (Rural) sounds
}
