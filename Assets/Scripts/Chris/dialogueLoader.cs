using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogueLoader : MonoBehaviour
{
    public DialogueLib _lib;
    public DialogueLib.LevelName _name;
    int i;

    public void StartDialogue(Text DialogueText, int index, AudioSource audio)
    {
        i = 0;
        DialogueText.text = _lib.dialogue[0];
        audio.clip = _lib.audio[0];
        audio.Play();
    }

    public void ChangeDialogue(Text DialogueText, int index, AudioSource audio)
    {
        i += index;
        if (i >= 0 && i <= 2)
        {
            DialogueText.text = _lib.dialogue[i];
            audio.clip = _lib.audio[i];
            audio.Play();
        }
        if(i < 0)
        {
            i = 2;
            DialogueText.text = _lib.dialogue[i];
            audio.clip = _lib.audio[i];
            audio.Play();
        }
        if (i > 2)
        {
            i = 0;
            DialogueText.text = _lib.dialogue[i];
            audio.clip = _lib.audio[i];
            audio.Play();
        }
    }
}
