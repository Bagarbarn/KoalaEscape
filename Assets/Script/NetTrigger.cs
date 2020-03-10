using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collided_gameobject = collision.gameObject;
        if(collided_gameobject.tag == "Player")
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
