using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDown : MonoBehaviour
{
    public TextMeshPro TimerText;
    public TextMeshPro TimerText2;
    public float time;
    public string minutes;
    public string seconds;
    private bool GameGo = true;

    private void OnEnable()
    {
        GameEvents.LevelWin += LevelWin;
        GameEvents.OnGameOver += LevelLose;
    }

    private void OnDisable()
    {
        GameEvents.LevelWin -= LevelWin;
        GameEvents.OnGameOver -= LevelLose;
    }

    private void LevelWin()
    {
        GameGo = false;
    }
    private void LevelLose(bool Die)
    {
        GameGo = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (GameGo)
        {
            time -= Time.deltaTime;
        }

        minutes = ((int)time / 60).ToString();
        seconds = (time % 60).ToString("f0");
        TimerText.text = minutes + ":" + seconds;
        TimerText2.text = minutes + ":" + seconds;

        if (time <= 0)
        {
            Debug.Log("Times Up");
            GameEvents.OnGameOver?.Invoke(true);
        }
    }
}
