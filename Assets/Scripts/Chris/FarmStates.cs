using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmStates: MonoBehaviour
{
    // cat objects
    public GameObject Farmer1;
    public GameObject Farmer2;
    private bool farmer = false;

    //dealer objects
    public GameObject Son1;
    public GameObject Son2;
    private bool son = false;

    // addict objects
    public GameObject Cow1;
    public GameObject Cow2;
    private bool cow = false;

    private string levelName;

    private void Awake()
    {
        levelName = PlayerPrefs.GetString("LevelName"); // get the completed level's name
        if (levelName == "Farmer")
        {
            //farmerBool = T
            PlayerPrefs.SetString("farmerBool", "T");
        }

        if(levelName == "Son")
        {
            //sonBool = T
            PlayerPrefs.SetString("sonBool", "T");
        }
        
        if(levelName == "Cow")
        {
            //cowBool = T
            PlayerPrefs.SetString("cowBool", "T");
        }
        
        if (PlayerPrefs.GetString("farmerBool") == "T")
        {
            //change Farmer Position
            Farmer1.SetActive(false);
            Farmer2.SetActive(true);
            farmer = true;
        }

        if (PlayerPrefs.GetString("sonBool") == "T")
        {
            //change Son Position
            Son1.SetActive(false);
            Son2.SetActive(true);
            son = true;
        }
        
        if (PlayerPrefs.GetString("cowBool") == "T")
        {
            //change Cow Position
            Cow1.SetActive(false);
            Cow2.SetActive(true);
            cow = true;
        }

        if (farmer && son && cow)
        {
            GameEvents.LevelWin?.Invoke();
        }

        //Save PlayerPrefs
        PlayerPrefs.Save();
    }
}
