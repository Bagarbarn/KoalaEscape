using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollision : MonoBehaviour
{
    Timer timer;
    public int addedValue = 0;
    public bool hideObjectOnCollision = false;
    private AudioSource audio_source_;
    public Renderer rend;
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        timer = FindObjectOfType<Timer>();
        audio_source_ = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !PlayerController.Instance.IsUnderground())
        {
           // Debug.Log("Collision");

            audio_source_.Play();

            PlayerController.Instance.PlayEffect(addedValue);

            if (hideObjectOnCollision) rend.enabled = false;

            timer.AddTime(addedValue);
        }
    }
}
