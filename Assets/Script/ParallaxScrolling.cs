using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScrolling : MonoBehaviour
{
    public List<GameObject> backgrounds_=new List<GameObject>();
    private float distance_;
    private GameObject player_;
    private int last_index_;
    public int counter=0;

    private void Awake()
    {
        player_ = GameObject.FindGameObjectWithTag("Player");
    }


    private void Start()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            backgrounds_.Add(transform.GetChild(i).gameObject);
        }
        distance_ = backgrounds_[0].GetComponent<SpriteRenderer>().bounds.max.y * 2;

        for (int i = 0; i < backgrounds_.Count; i++)
        {
            backgrounds_[i].transform.position = new Vector2(0, -(i * distance_));
        }
        last_index_ = backgrounds_.Count - 1;
    }

    private void Update()
    {
        if (player_.transform.position.y < backgrounds_[last_index_].GetComponentInChildren<SpriteRenderer>().bounds.max.y)
            Swap();
    }

    private void Swap()
    {
        counter++;
        backgrounds_[0].transform.position = new Vector2(0, backgrounds_[last_index_].GetComponent<SpriteRenderer>().bounds.max.y - distance_ * 1.5f);
        GameObject temp = backgrounds_[last_index_];
        backgrounds_[2] = backgrounds_[1];
        backgrounds_[1] = backgrounds_[0];
        backgrounds_[0] = temp;
    }
}
