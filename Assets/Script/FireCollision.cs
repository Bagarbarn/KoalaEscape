using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCollision : MonoBehaviour
{
    Timer timer;
    [SerializeField]
    float reductionValue;

    void Start()
    {
        timer = FindObjectOfType<Timer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            timer.ReduceTimer(reductionValue);
        }
    }
}
