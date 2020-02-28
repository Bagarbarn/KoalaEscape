using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCollision : MonoBehaviour
{
    Timer timer;
    public float reductionValue;
    private AudioSource audio_source_;

    void Start()
    {
        timer = FindObjectOfType<Timer>();
        audio_source_ = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audio_source_.Play();
            timer.ReduceTimer(reductionValue);
            
            if (reductionValue <= -1)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
