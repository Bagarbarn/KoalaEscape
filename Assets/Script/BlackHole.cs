using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    private Transform[] holes_ = new Transform[2];
    
    public float distance_between_holes_;

    void Awake()
    {
        for(int i = 0; i < holes_.Length; i++)
        {
            holes_[i] = transform.GetChild(i);
        }
    }

    private void Start()
    {
        holes_[0].position = new Vector2(transform.position.x, transform.position.y + (distance_between_holes_ / 2));
        holes_[1].position = new Vector2(transform.position.x, transform.position.y - (distance_between_holes_ / 2));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
