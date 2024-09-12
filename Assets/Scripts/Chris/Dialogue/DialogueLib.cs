using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "DialogueLibrary", fileName = "Dialogue"),]
public class DialogueLib : ScriptableObject
{
    public enum LevelName
    {
        cat1, cat2, dealer1, dealer2, addict1, addict2,
        mum1, mum2, cigs1, cigs2, pill1, pill2,
        farmer1, farmer2, son1, son2, cow1, cow2,
        CEO1, CEO2, intern1, intern2, accountant1, accountant2,
        collectable
    }

    public LevelName _name;
    public string[] dialogue;
    public AudioClip[] audio;
}
