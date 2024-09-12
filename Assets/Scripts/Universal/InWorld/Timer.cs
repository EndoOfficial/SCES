using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text TimerText;
    public Text BestTime;
    public float Record;
    public float StartTime;
    private float t;
    public float BMinutes;

    private Scene C_Scene;
    public string SceneName;
    private bool Finished = false;
    public bool IsTimedLevel = true;

    public string minutes;
    public string seconds;

    public string RMinutes;
    public string RSeconds;

    public float _time;

    private LevelTime FoundTime;

    public LevelTimes TimesLibrary;
    private void Start()
    {
        //StartTime = Time.time;
        _time = 0;

        TimerText = GameObject.Find("TimerText").GetComponent<Text>();
        BestTime = GameObject.Find("BestTime").GetComponent<Text>();
        //TimerText.text = PlayerPrefs.GetString("LevelTime", seconds);
        //SceneName = PlayerPrefs.GetString("LevelName", SceneName);

        //Debug.Log(StartTime);
        //Debug.Log(SceneName);

        TimerText.text = StartTime.ToString("f2");

        minutes = "";
        seconds = "";

        C_Scene = SceneManager.GetActiveScene();
        SceneName = C_Scene.name;

        FoundTime = LookUpTime(SceneName);

        if(FoundTime == null)
        {
            //Debug.LogError($"No Name Found {SceneName}");
            IsTimedLevel = false;
            
        }
        else
        {
            IsTimedLevel = true;
            Record = FoundTime.Time;

            RMinutes = ((int)Record / 60).ToString();
            RSeconds = (Record % 60).ToString("f2");
            BestTime.text = RMinutes + ":" + RSeconds;

            

            //FoundTime.Time.ToString("f2");
        }
        if(Record <= 0)
        {
            BestTime.gameObject.SetActive (false);
        }
        else
        {
            BestTime.gameObject.SetActive(true);
        }
        
    }

    
    private void Update()
    {

        if (!IsTimedLevel)
        {
            TimerText.gameObject.SetActive(false);
            return;
        }
        else
        {
            TimerText.gameObject.SetActive(true);
        }
            
        
        if (Finished)
            return;

        _time += Time.deltaTime;
        t = _time;
        minutes = ((int)t / 60).ToString();
        seconds = (t % 60).ToString("f2");

        TimerText.text = minutes + ":" + seconds;
    }

    public LevelTime LookUpTime(string LevelName)
    {
        foreach(LevelTime levelTime in TimesLibrary.times)
        {
            if(LevelName == levelTime.LevelName)
            {
                return levelTime;
            }
        }
        return null;
    }
    
    public void Finnnish()
    {
        if(t < Record || Record == 0)
        {
            FoundTime.Time = t;
            if(Record >= 60)
            {
               
            }

        }
        Debug.Log(SceneName);
        Finished = true;
        TimerText.color = Color.red;
    }
}
