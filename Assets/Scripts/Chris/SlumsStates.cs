using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlumsStates : MonoBehaviour
{
    // cat objects
    public GameObject Cat1;
    public GameObject Cat2;
    private bool cat = false;

    //dealer objects
    public GameObject Dealer1;
    public GameObject Dealer2;
    private bool dealer = false;

    // addict objects
    public GameObject Addict1;
    public GameObject Addict2;
    private bool addict = false;

    private string levelName;

    private void Awake()
    {
        levelName = PlayerPrefs.GetString("LevelName"); // get the completed level's name
        if (levelName == "Cat")
        {
            // set catBool to T
            PlayerPrefs.SetString("catBool", "T");
        }

        if(levelName == "Addict")
        {
            // set addictBool to T
            PlayerPrefs.SetString("addictBool", "T");
        }
        
        if(levelName == "Dealer")
        {
            // set dealerBool to T
            PlayerPrefs.SetString("dealerBool", "T");
        }
        
        if (PlayerPrefs.GetString("catBool") == "T")
        {
            // cat changes position
            Cat1.SetActive(false);
            Cat2.SetActive(true);
            cat = true;
        }

        if (PlayerPrefs.GetString("dealerBool") == "T")
        {
            //Dealer changes position
            Dealer1.SetActive(false);
            Dealer2.SetActive(true);
            dealer = true;
        }
        
        if (PlayerPrefs.GetString("addictBool") == "T")
        {
            //addict changes position
            Addict1.SetActive(false);
            Addict2.SetActive(true);
            addict = true;
        }

        if(cat && addict && dealer)
        {
            GameEvents.LevelWin?.Invoke();
        }

        //Save PlayerPrefs
        PlayerPrefs.Save();
    }
}
