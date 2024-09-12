using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApartmentStates: MonoBehaviour
{
    // cat objects
    public GameObject Mum1;
    public GameObject Mum2;
    private bool mum = false;

    //dealer objects
    public GameObject Pill1;
    public GameObject Pill2;
    private bool pill = false;

    // addict objects
    public GameObject Cigs1;
    public GameObject Cigs2;
    private bool cigs = false;

    private string levelName;

    private void Awake()
    {
        levelName = PlayerPrefs.GetString("LevelName"); // get the completed level's name
        if (levelName == "Mum")
        {
            //mumBool = T
            PlayerPrefs.SetString("mumBool", "T");
        }

        if(levelName == "Pill")
        {
            //pillBool = T
            PlayerPrefs.SetString("pillBool", "T");
        }
        
        if(levelName == "Cigs")
        {
            //cigsBool = T
            PlayerPrefs.SetString("cigsBool", "T");
        }
        
        if (PlayerPrefs.GetString("mumBool") == "T")
        {
            //change Mum Position
            Mum1.SetActive(false);
            Mum2.SetActive(true);
            mum = true;
        }

        if (PlayerPrefs.GetString("pillBool") == "T")
        {
            //change Pill Position
            Pill1.SetActive(false);
            Pill2.SetActive(true);
            pill = true;
        }
        
        if (PlayerPrefs.GetString("cigsBool") == "T")
        {
            //change Cigs Position
            Cigs1.SetActive(false);
            Cigs2.SetActive(true);
            cigs = true;
        }

        if (mum && pill & cigs)
        {
            GameEvents.LevelWin?.Invoke();
        }

        //Save PlayerPrefs
        PlayerPrefs.Save();
    }
}
