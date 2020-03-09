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
    private bool trapped = false;
    private int keyspam = 0;
    public int spamnr;

    private Rigidbody2D rb2d;
    bool stateLock;

    //ALEX CAM
    float lockX;
    public Transform cam;
    //ALEX CAM END


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
        int dir = Mathf.RoundToInt(Input.GetAxis("Horizontal"));
        //Debug.Log("side " + dir);
        if (trapped == false)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeedHorizontal;
            verticalMove = -moveSpeedVertical;

            moveDirection = new Vector2(horizontalMove, verticalMove);

            transform.position += moveDirection * Time.deltaTime;

            //ALEX CAMERA
            lockX = Mathf.Clamp(cam.position.x, 0, 0);
            cam.position = new Vector3(lockX, cam.position.y, cam.position.z);
            //ALEX CAMERA END
        }

        else

        {

            //ALEX INTERFERENCE
            
           /* float dir = Input.GetAxis("Horizontal");
            Debug.Log("side " + dir);*/
            if (dir !=0)
            {
                
                keyspam++;
                Debug.Log(keyspam);

            }
            
            if (keyspam >= spamnr)
            {
                trapped = false;
                keyspam = 0;
            }
            //ALEX INTERFERENCE END
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            trapped = true;
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




