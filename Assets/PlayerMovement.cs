using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    //public float moveSpeed;
    public float moveSpeedHorizontal;

    private Vector3 moveDirection;

    float horizontalMove = 0f;
    //float verticalMove = 0f;
    // Start is called before the first frame update
    void Start()
    {
        moveDirection = Vector3.down;
        //transform.position += (moveDirection * moveSpeed * Time.deltaTime);

        //*erticalMove = Input.GetAxisRaw*

    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");

        moveDirection.x = horizontalMove;

        transform.position += (moveDirection * moveSpeedHorizontal * Time.deltaTime);
    }

    void FixedUpdate()
    {
        ///controller.Move(horizontalMove * Time.fixedDeltaTime);

    }
}