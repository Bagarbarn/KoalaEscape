using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public enum TimerType
{
    Increment,
    Decrement
}

public class Timer : MonoBehaviour {
    public TextMeshProUGUI timeText;
    public UnityEvent onTimeStart;
    public UnityEvent onTimeEnd;
    private TimerType timerTimerType;
    DateTime startTime;
    public int startTimeSeconds = 60;
    public bool startOnAwake = false;
    public bool TimerWorking = false;

    public string prefix = "Time: ";
    public string suffix = "";
    public int gameSeconds = 0;

    public int totalTime = 0;

    public int mins = 0;
    public int seconds = 0;
    public int timeScoreCounter = 0;

    private int step = 1;
    public static Timer Instance;

    // LOSE SCREEN
    public GameObject loseScreen;
    //LOSE SCREEN END
    

    public TimerType TimerTimerType
    {
        get
        {
            return timerTimerType;
        }

        set
        {
            timerTimerType = value;
            switch (value)
            {
                case TimerType.Increment:
                    step = 1;
                    break;
                case TimerType.Decrement:
                    step = -1; 
                    break;
            }
        }
    }

    private void Awake()
    {
        
        //timeScoreCounter = 
        if (Instance == null) Instance = this;
        TimerTimerType = TimerType.Decrement;

        if (timeText == null) timeText = this.GetComponent<TextMeshProUGUI>();
        if (timeText == null) timeText = this.GetComponentInChildren<TextMeshProUGUI>();
        if (timeText == null) Debug.LogError("No Text on the object");
        if (startOnAwake)
        {
            StartTimer(startTimeSeconds);
        }
    }

    public void StopTimer()
    {
        TimeEnded();
    }


    public void AddTime(int timeAdded = 0)
    {
        gameSeconds += timeAdded;
        if (gameSeconds <= 0) gameSeconds = 1;
        CalculateTime();
    }
    public void StartTimer(int totalSeconds,TimerType type = TimerType.Decrement)
    {
        TimerWorking = true;
        startTime = DateTime.Now;
        gameSeconds = totalSeconds/*+3*/;
        TimerTimerType = type;

        CalculateTime();
        StartCoroutine(TimeTick());
        totalTime = totalSeconds - 3;
        timeScoreCounter = 0;

        onTimeStart?.Invoke();
    }

    

    private IEnumerator TimeTick()
    {
        while (true)
        {
            gameSeconds += step;

            if (TimerTimerType == TimerType.Decrement)
            {
                if (timeScoreCounter < totalTime)
                {
                    timeScoreCounter += 1;
                }
            }
            CalculateTime();

            if (TimerTimerType == TimerType.Decrement)
            {
                if (gameSeconds == 0) TimeEnded();
            }
               
            yield return new WaitForSeconds(1);

        }
    }

    private void CalculateTime()
    {
        mins = gameSeconds / 60;
        seconds = gameSeconds - mins * 60;
        UpdateText(seconds, mins);
    }

    public void TimeEnded()
    {
        //TimerWorking = false;
        //Debug.Log("Time ended");
        onTimeEnd.Invoke();

        

        StopAllCoroutines();

        //LOSE SCREEN 
        StartCoroutine("Lose");
        //LOSE SCREEN END

        CalculateTime();
    }
    #region loseScreen
    IEnumerator Lose ()
    {
        loseScreen.SetActive(true);
        yield return new WaitForSeconds(3);
        loseScreen.SetActive(false);
        SceneManager.LoadScene(0);
    }
    #endregion loseScreen

    string minsString = "";
    string secsString = "";
    string timeString = "";
    private void UpdateText(int seconds, int mins)
    {
        minsString = mins.ToString();
        if (seconds < 0) seconds = 0;
        secsString = seconds.ToString();

        if (mins < 10) minsString = "0" + mins.ToString();
        if (seconds < 10) secsString = "0" + seconds.ToString();
        timeString = prefix + (minsString + ":" + secsString) + suffix;
        timeText.text = timeString;
    }

    private void TimerNotWorking()
    {
        timeText.text = " ";
    }


    private void Update()
    {
        if (!TimerWorking)
        {
            TimerNotWorking();
        }
    }
}
