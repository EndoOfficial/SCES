using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(menuName = "LevelTimes", fileName = "Times")] // This is the name of the level times
public class LevelTimes : ScriptableObject
{
    public LevelTime[] times;
}


[System.Serializable]
    public class LevelTime
    {
        public string LevelName;
        public float Time;
    }