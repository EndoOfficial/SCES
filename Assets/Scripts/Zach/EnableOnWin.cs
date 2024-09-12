using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnableOnWin : MonoBehaviour
{

    private void OnEnable()
    {
        GameEvents.LevelWin += LevelWin;
    }
    private void OnDisable()
    {
        GameEvents.LevelWin -= LevelWin;
    }
    
    public void LevelWin()
    { //generates an array of child objects to enable on game win
        var childCount = transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            var child = transform.GetChild(i);
            child.transform.gameObject.SetActive(true);
        }
    }
}
