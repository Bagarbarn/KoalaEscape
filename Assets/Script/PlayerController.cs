using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float speed;

    private Rigidbody2D rb2d;
    bool stateLock;

    [SerializeField]
    CircleCollider2D circleCollider2D;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
      
     if(Input.GetKeyDown(KeyCode.R))
            Application.LoadLevel(Application.loadedLevel);
    
        //if (!stateLock&& Input.GetKey(KeyCode.Space))
        
            //stateLock = true;
            //circleCollider2D.enabled = false;
            //StartCoroutine("Jump");
        
    }

    //public IEnumerator Jump()
    
        //yield return new WaitForSeconds(1);
        //circleCollider2D.enabled=true;
        //stateLock = false;

    

    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = -1; //Input.GetAxis("Vertical");
  
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacles")
        {
            //do something
        }
    }

}
