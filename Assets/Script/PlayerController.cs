using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeedHorizontal;
    private float horizontalMove;
    private float verticalMove;
    public float moveSpeedVertical;
    private Vector3 moveDirection;


    private Rigidbody2D rb2d;
    bool stateLock;

    [SerializeField]
    CircleCollider2D circleCollider2D;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    //private void Update()
    //{

    //    //if(Input.GetKeyDown(KeyCode.R))
    //    //       Application.LoadLevel(Application.loadedLevel);

    //    //if (!stateLock&& Input.GetKey(KeyCode.Space))

    //    //stateLock = true;
    //    //circleCollider2D.enabled = false;
    //    //StartCoroutine("Jump");

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeedHorizontal;
        verticalMove = -moveSpeedVertical;

        moveDirection = new Vector2(horizontalMove, verticalMove);

        transform.position += moveDirection * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacles")
        {
            //do something
        }
    }


}

//public IEnumerator Jump()

//yield return new WaitForSeconds(1);
//circleCollider2D.enabled=true;
//stateLock = false;



//void FixedUpdate()
//{

//    float moveHorizontal = Input.GetAxis("Horizontal");
//    float moveVertical = -4; Input.GetAxis("Vertical");

//    Vector2 movement = new Vector2(moveHorizontal, moveVertical);
//    rb2d.AddForce(movement * speed);

//}




