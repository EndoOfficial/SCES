using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGame : MonoBehaviour
{
  
    public void ResetPrefs()
    {
        PlayerPrefs.SetString("mumBool", "F");
        PlayerPrefs.SetString("cigsBool", "F");
        PlayerPrefs.SetString("pillBool", "F");
        PlayerPrefs.SetString("ceoBool", "F");
        PlayerPrefs.SetString("internBool", "F");
        PlayerPrefs.SetString("accountantBool", "F");
        PlayerPrefs.SetString("catBool", "F");
        PlayerPrefs.SetString("addictBool", "F");
        PlayerPrefs.SetString("dealerBool", "F");
        PlayerPrefs.SetString("farmerBool", "F");
        PlayerPrefs.SetString("sonBool", "F");
        PlayerPrefs.SetString("cowBool", "F");
    }
}
