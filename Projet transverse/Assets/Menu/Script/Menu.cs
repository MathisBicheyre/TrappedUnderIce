﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{


    void Start()
    {

    }


    void Update()
    {

    }

    public void Play()
    {
        SceneManager.LoadScene("VraiTuto");
    }


    public void Resume()
    {
        if (PlayerPrefs.HasKey("LevelToLoad"))
        {
            SceneManager.LoadScene(PlayerPrefs.GetString("LevelToLoad"));
        }
        else
        {
            SceneManager.LoadScene("VraiTuto");
        }
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void Quit()
    {
        Application.Quit();
    }
}

