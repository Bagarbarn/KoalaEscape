﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    private void Awake()
    {
        Time.timeScale = 1;
    }
    public void PlayGame ()
  
    {
        SceneManager.LoadScene("adamLevel");
    }
   
}
