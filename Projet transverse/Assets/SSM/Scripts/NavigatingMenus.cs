using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class NavigatingMenus : MonoBehaviour
{
    public SSMPlayer script_SSMPlayer;

    // IN THE MAIN MENU
    public GameObject Menu_Credits;
    public GameObject Menu_Intro;
    public GameObject Menu_Main;
    public GameObject Menu_Settings;
    public GameObject Button_SSM;
    private bool credits;
    private int Current_Menu;
    /*
    1 - Menu_Intro
    2 - Menu_Main
    3 - Menu_Setings
    4 - Menu Credits
    */
    

    /// - - - - - - - - - -- - -- - - - -- - -   CHANGING SCENE


    public void Go_To_Scene_MainMenu()
    {
        Debug.Log("Entering the Intro Menu !!");
        SceneManager.LoadScene("SSM_Scene_Menu");
    }

    public void Go_To_Scene_NewGame()
    {
        Debug.Log("Entering a New Game !!");
        SceneManager.LoadScene("SSM_Scene_NewGame");
    }

    public void Go_To_Scene_SavedGame()
    {
        Debug.Log("Entering a Saved Game !!");
        SceneManager.LoadScene("SSM_Scene_SavedGame");
    }

    public void Go_To_Scene_Ingame()
    {
        Debug.Log("Entering the Game !!");
        SceneManager.LoadScene("SSM_Scene_InGame");
    }


    /// - - - - - - - - - -- - -- - - - -- - -   CHANGING MENU


    public void Lauching_MainMenu()
    {
        Debug.Log("Entering the Main Menu !!");
        
        Current_Menu = 2;
        Menu_Credits.SetActive(false);
        Menu_Intro.SetActive(false);
        Menu_Settings.SetActive(false);
        Menu_Main.SetActive(true);
    }

    public void Using_MenuCredits()
    {
        if (credits == false)
        {
            Debug.Log("Entering the Credits Menu !!");
            if (Current_Menu == 2) Menu_Main.SetActive(false);
            if (Current_Menu == 3) Menu_Settings.SetActive(false);
            Menu_Credits.SetActive(true);
        }
        else
        {
            Menu_Credits.SetActive(false);
            if (Current_Menu == 2) Lauching_MainMenu();
            if (Current_Menu == 3) Lauching_MenuSettings();
        }
        credits = !credits;
    }

    public void Lauching_MenuSettings()
    {
        Debug.Log("Entering the Settings Menu !!");

        Current_Menu = 3;
        Menu_Main.SetActive(false);
        Menu_Settings.SetActive(true);
    }


    public void Quit_Game()
    {
        Debug.Log("Quitting Super-Salary Man !!");
        SceneManager.LoadScene("NextLevel");
    }


    public bool IsInputCorrect()
    {
        if (Input.GetKeyUp(KeyCode.Space)
        || Input.GetKeyUp(KeyCode.Return)
        || Input.GetKeyUp(KeyCode.Mouse0)
        || Input.GetKeyUp(KeyCode.Mouse1)) return true;
        else return false;
    }


    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "SSM_Scene_Menu")
        {
            Current_Menu = 1;
            credits = false;
            Menu_Intro.SetActive(true);
            Menu_Main.SetActive(false);
            Menu_Settings.SetActive(false);
            Button_SSM.SetActive(false);
        }
    }


    void Update()
    {
        if ((SceneManager.GetActiveScene().name == "SSM_Scene_Menu")
           && Menu_Intro.activeInHierarchy
           && IsInputCorrect())
        {
            Lauching_MainMenu();
            Button_SSM.SetActive(true);
        }
    }
}
