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
    public Pooler timeEffectPool;
    private Rigidbody2D rb2d;
    bool stateLock;


    private static PlayerController instance;

    //ALEX CAM
    float lockX;
    public Transform cam;
    //ALEX CAM END


    [SerializeField]
    CircleCollider2D circleCollider2D;

    public float MoveSpeedVertical { get => moveSpeedVertical; set => moveSpeedVertical = value; }
    public static PlayerController Instance { get => instance; set => instance = value; }


    public float startYForEffect = 2.2f;
    public float endYForEffect = 3.2f;

    void Awake()
    {
        if (instance == null) instance = this;
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

    public void PlayEffect(int value)
    {
        TimeChangeEffect timeeffect = timeEffectPool.Get(true).GetComponent<TimeChangeEffect>();
        string valuesent = value > 0 ? "+" + value + "s" :  value + "s";
        timeeffect.ShowEffect(valuesent, startYForEffect, endYForEffect);
    }

    void Update()
    {
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
            var dir = Input.GetAxis("Horizontal");
            if (dir !=0)
            {
                keyspam++;
            }

            if (keyspam == spamnr)
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




