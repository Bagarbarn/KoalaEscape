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
    private bool is_underground_ = false;
    public ParticleSystem dust_;
    public float firstAccumulatedSpeed;
    public float secondAccumulatedSpeed;
    public float thirdAccumulatedSpeed;

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
        int dir = Mathf.RoundToInt(Input.GetAxis("Horizontal"));

        if (trapped == false)
        {
            if (!is_underground_)
            {
                horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeedHorizontal;
            }
            else
            {
                horizontalMove = 0.0f;
            }
           
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

            if (dir !=0)
            {
                keyspam++;
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
        GameObject collided_object = collision.gameObject;
        if (collided_object.tag == "Trap" && !is_underground_)
        {
            trapped = true;
        }

        if (collided_object.tag == "Speed Accumulator 1")
        {
            moveSpeedVertical = firstAccumulatedSpeed;
        }
        else if (collided_object.tag == "Speed Accumulator 2")
        {
            moveSpeedVertical = secondAccumulatedSpeed;
        }
        else if (collided_object.tag == "Speed Accumulator 3")
        {
            moveSpeedVertical = thirdAccumulatedSpeed;
        }

        if(collided_object.tag == "Finish Line")
        {
            SceneManager.LoadScene("Win Scene");
        }

    }

    public void SetUnderground(bool is_underground) {
        is_underground_ = is_underground;
        GetComponent<SpriteRenderer>().enabled = !is_underground_;
        GetComponent<CircleCollider2D>().isTrigger = is_underground_;
        if (is_underground_ && !dust_.isPlaying) dust_.Play();
        else dust_.Stop();
    }
    public bool IsUnderground() { return is_underground_; }

   
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




