using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public GameObject PauseUI;

    private bool paused = false;

    void Start()
    {
        PauseUI.SetActive(false);
    }

    void Update()
    {
        if(Input.GetButtonDown("Pause"))
        {
            paused = !paused;
        }

        if(paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }

        if(!paused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;     //between 0 and 1 = slowmotion
        }
    }

    public void Resume()
    {
        paused = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene("VraiTuto");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Settings()
    {
        SceneManager.LoadScene("Options");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
