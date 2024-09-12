using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    enum SceneName 
    {
        Slums, Apartment, Farm, Corpo,
        Pill, Spreadsheet, Bills, 
        Fire, Fish, Cocaine, Faceless, 
        Hands, Syringe, Ciggs, KneeMan, 
        PT, MainMenu, NewGameIntro, 
        CorpoIntro, ApartmentIntro, 
        FarmIntro, SlumsIntro, LevelMenu
    }
    [SerializeField]
    private SceneName sceneName;

    enum LevelName { None, Cat, Addict, Dealer, Mum, Pill, Cigs, Farmer, Son, Cow, CEO, Intern, Accountant };
    [SerializeField]
    private LevelName levelName;
    public void LoadScene()
    {
        PlayerPrefs.SetString("LevelName", levelName.ToString());
        SceneManager.LoadScene(sceneName.ToString());
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting game....");
    }
}