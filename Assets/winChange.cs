using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winChange : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject endScreen;

    [HideInInspector]
    public bool won = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            won = true;
            StartCoroutine("Winner");
            
        }
    }
    IEnumerator Winner()
    {
        winScreen.SetActive(true);
        yield return new WaitForSeconds(3);
        winScreen.SetActive(false);
        if ((SceneManager.GetActiveScene().buildIndex) < 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            won = false;
        }
        else endScreen.SetActive(true);
        
    }


}
