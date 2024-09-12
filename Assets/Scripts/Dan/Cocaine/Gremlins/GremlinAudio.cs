using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GremlinAudio : MonoBehaviour
{
    private AudioSource source;
    // Start is called before the first frame update
   
    private void DeathSound()
    {
        // Gets the audio source and plays the audio from the corporate library, we do this trough the animations
        source = GetComponent<AudioSource>();
        GameEvents.OnCorporateplayAudio?.Invoke(source,AudioManager.CorporateClipTags.CokeDeath);
    }
    private void CokePuffSound()
    {
        // Gets the audio source and plays the audio from the corporate library, we do this trough the animations
        source = GetComponent<AudioSource>();
        GameEvents.OnCorporateplayAudio?.Invoke(source,AudioManager.CorporateClipTags.PuffNoise);
    }
}
