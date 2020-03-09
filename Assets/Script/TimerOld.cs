using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerOld : MonoBehaviour
{
    [Range(60f, 300f)]
    public float maxTimer;
    float timer;
    public Text timerText;
    public GameObject loseScreen;
    bool GameOver;
    ParallaxScrolling parallaxScrolling;
    public Text loseWinText;
    public string losingText;
    public string winningText;
    [Tooltip("Keep the value even always")]
    public int counterRequired;
    public string nextscene;
    public float targetTime;
    public bool lastlevel = false;

    private AudioSource audio_source_;
    public AudioClip win_clip_;
    public AudioClip lose_clip_;

    private PlayerController player_controller_;

  /*  void Awake()
    {
        parallaxScrolling = FindObjectOfType<ParallaxScrolling>();
        Time.timeScale = 1;
        loseScreen.SetActive(false);
        timer = maxTimer;

        audio_source_ = GetComponent<AudioSource>();
        player_controller_ = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }*/

    private void Start()
    {
        audio_source_.Play();
        targetTime = 3f;
    }

   /* public void ReduceTimer(float reductionValue)
    {
        timer -= reductionValue;
    }*/

   /* void Update()
    {
        if (!GameOver) timer -= Time.deltaTime;

        string minutes = Mathf.Floor(timer / 60).ToString("00");
        string seconds = (timer % 60).ToString("00");
        timerText.text = "Time Left: " + minutes + ":" + seconds;
        if (timer <= 0 && !GameOver)
        {
            SetLose();
           
            loseScreen.SetActive(true);
            loseWinText.text = losingText;
            GameOver = true;
        }
        if (parallaxScrolling.counter == counterRequired && !GameOver)
        {
            SetWin();
            
            loseScreen.SetActive(true);
            loseWinText.text = winningText;
            if (lastlevel == true)
            {
               GameOver = true;
            }


            targetTime -= Time.deltaTime;
           

            if (targetTime <= 0.0f)
            {
                SceneManager.LoadScene(nextscene);
            }
        }

        if (GameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("MainMenu");
        }
    } */

    private void SetWin()
    {
        audio_source_.clip = win_clip_;
        audio_source_.loop = false;
        if (!audio_source_.isPlaying)
        {
            audio_source_.Play();
        }
        player_controller_.enabled = false;
    }

    private void SetLose()
    {
        audio_source_.clip = lose_clip_;
        audio_source_.loop = false;
        if (!audio_source_.isPlaying)
        {
            audio_source_.Play();
        }
        player_controller_.enabled = false;
    }
}
