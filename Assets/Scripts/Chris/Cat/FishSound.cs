using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSound : MonoBehaviour
{
    public void DieSound() { GameEvents.OnSlumsplayAudio?.Invoke(GetComponent<AudioSource>(), AudioManager.SlumsClipTags.FishDie); }
}
