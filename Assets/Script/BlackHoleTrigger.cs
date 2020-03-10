using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleTrigger : MonoBehaviour
{
    private PlayerController player_controller_;

    private void Start()
    {
        player_controller_ = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collided_object = collision.gameObject;

        if(collided_object.tag == "Player")
        {
            if(tag == "Black Hole Entrance")
            {
                player_controller_.SetUnderground(true);
            }
            else if(tag == "Black Hole Exit")
            {
                player_controller_.SetUnderground(false);

            }
        }
    }
}
