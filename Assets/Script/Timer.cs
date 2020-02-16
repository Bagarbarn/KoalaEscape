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
    public GameObject loseScreen;
    bool GameOver;
    ParallaxScrolling parallaxScrolling;
    public Text loseWinText;
    [SerializeField]
    string losingText;
    [SerializeField]
    string winningText;
    [Tooltip("Keep the value even always")]
    public int counterRequired;

    void Awake()
    {
        parallaxScrolling = FindObjectOfType<ParallaxScrolling>();
        Time.timeScale = 1;
        loseScreen.SetActive(false);
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
        if (timer <= 0)
        {
            Time.timeScale = 0;
            loseScreen.SetActive(true);
            loseWinText.text = losingText;
        }
        if (parallaxScrolling.counter == counterRequired)
        {
            Time.timeScale = 0;
            loseScreen.SetActive(true);
            loseWinText.text = winningText;
        }
    }
}
