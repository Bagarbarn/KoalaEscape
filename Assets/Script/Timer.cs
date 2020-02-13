using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [Range(60f,300f)]
    public float maxTimer;
    float timer;
    public Text timerText;

    void Awake()
    {
        timer = maxTimer;
    }

    public void ReduceTimer(float reductionValue)
    {
        timer -= reductionValue;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        string minutes = Mathf.Floor(timer / 60).ToString("00");
        string seconds = (timer % 60).ToString("00");
        timerText.text = "Time Left: " + minutes + ":" + seconds ;
    }
}
