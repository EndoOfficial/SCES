using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperAudio : MonoBehaviour
{
    public void Death() { GameEvents.OnSlumsplayAudio?.Invoke(GetComponent<AudioSource>(), AudioManager.SlumsClipTags.BillPaperDeath); }
}
