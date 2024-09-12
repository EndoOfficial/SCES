using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorpoStates: MonoBehaviour
{
    private int areaWin = 0;

    // cat objects
    public GameObject CEO1;
    public GameObject CEO2;

    //dealer objects
    public GameObject Intern1;
    public GameObject Intern2;

    // addict objects
    public GameObject Accountant1;
    public GameObject Accountant2;

    private string levelName;

    private void Awake()
    {
        areaWin = 0;
        levelName = PlayerPrefs.GetString("LevelName"); // get the completed level's name
        if (levelName == "CEO")
        {
            //farmerBool = T
            PlayerPrefs.SetString("ceoBool", "T");
        }

        if(levelName == "Intern")
        {
            //sonBool = T
            PlayerPrefs.SetString("internBool", "T");
        }
        
        if(levelName == "Accountant")
        {
            //cowBool = T
            PlayerPrefs.SetString("accountantBool", "T");
        }
        
        if (PlayerPrefs.GetString("ceoBool") == "T")
        {
            //change Farmer Position
            CEO1.SetActive(false);
            CEO2.SetActive(true);
            areaWin++;
        }

        if (PlayerPrefs.GetString("internBool") == "T")
        {
            //change Son Position
            Intern1.SetActive(false);
            Intern2.SetActive(true);
            areaWin++;
        }
        
        if (PlayerPrefs.GetString("accountantBool") == "T")
        {
            //change Cow Position
            Accountant1.SetActive(false);
            Accountant2.SetActive(true);
            areaWin++;
        }

        if (areaWin == 3)
        {
            GameEvents.LevelWin?.Invoke();
        }

        //Save PlayerPrefs
        PlayerPrefs.Save();
    }
}
