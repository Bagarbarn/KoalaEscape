using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Net : MonoBehaviour
{
    [Range(-1, 1)]
    public float horizontal_move_;
    [Range(-1, 1)]
    public float vertical_move_;

    public float speed_;
    public Text tutorial_text_;

    private Vector3 move_direction_;
    private void Start()
    {
        if (horizontal_move_ < 0) horizontal_move_ = -1;
        else if (horizontal_move_ > 0) horizontal_move_ = 1;
        if (vertical_move_ < 0) vertical_move_ = -1;
        else if (vertical_move_ > 0) vertical_move_ = 1;

        move_direction_.x = horizontal_move_;
        move_direction_.y = vertical_move_;
        move_direction_.z = 0.0f;
    }
    private void Update()
    {
        transform.position += move_direction_ * Time.deltaTime * speed_;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collided_object = collision.gameObject;

        if (collided_object.tag == "Player")
        {
            horizontal_move_ = 0f;
            if (tutorial_text_ != null)
            {
                tutorial_text_.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject collided_object = collision.gameObject;

        if (collided_object.tag == "Player")
        {
            if (tutorial_text_ != null)
            {
                tutorial_text_.gameObject.SetActive(false);
            }
        }
    }

   


}
