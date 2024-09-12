using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UiManager : MonoBehaviour
{
    public GameObject GameOverMenuUi;

    public GameObject dialoguePanel;
    public GameObject LoadingPanel;

    public GameObject Wave1TXT;
    public GameObject GameWinTXT;

    //public TextMeshProUGUI HealthText;
    private void OnEnable()
    {
        GameEvents.OnGameOver += OnGameOver;
        GameEvents.UIPanelToggle += UIPanelToggle;
        GameEvents.UILoading += UILoading;
        GameEvents.NewWave += Wave1;
        GameEvents.WaveWin += OnWaveWin;
    }
    private void OnDisable()
    {
        GameEvents.OnGameOver -= OnGameOver;
        GameEvents.UIPanelToggle -= UIPanelToggle;
        GameEvents.UILoading -= UILoading;
        GameEvents.NewWave -= Wave1;
        GameEvents.WaveWin -= OnWaveWin;
    }

    private void UILoading(bool active)
    {
        LoadingPanel.SetActive(active);
    }

    public void OnGameOver(bool gameover)
    {
        //FindObjectOfType<AudioManager>().Play("GameOver");
        
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        GameOverMenuUi.SetActive(true);
        //GameObject slider = gameObject.transform.Find("Slider").gameObject;
        //Destroy(slider);
        
    }
    private void UIPanelToggle(bool active)
    {
        dialoguePanel.SetActive(active);
    }

    public void Wave1()
    {
        Wave1TXT.SetActive(true);
        StartCoroutine(WaveTxtDissapear());
        
        
    }

    IEnumerator WaveTxtDissapear()
    {
        yield return new WaitForSeconds(4);
        Wave1TXT.SetActive(false);
    }
    public void OnWaveWin()
    {
        GameWinTXT.SetActive(true);
        StartCoroutine(WinWaveDis());
    }

    IEnumerator WinWaveDis()
    {
        yield return new WaitForSeconds(4);
       GameWinTXT.SetActive(false);
    }
    //public void CurrentHealth(int health)
    //{
    //    HealthText.text = "PlayerHp: " + health.ToString();
    //}

}
