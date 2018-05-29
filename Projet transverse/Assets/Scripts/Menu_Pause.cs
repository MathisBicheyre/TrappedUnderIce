using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu_Pause : MonoBehaviour
{
    private bool X;
    public GameObject MenuPause;


    public void _Resume_Game()
    {
        X = false;
        MenuPause.SetActive(false);
    }

    public void _Get_Back_To_Main_Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    // Use this for initialization
    void Start ()
    {
        X = false;
        MenuPause.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyUp(KeyCode.Escape))
        {
            X = !X;
            if(X) MenuPause.SetActive(true);
            else MenuPause.SetActive(false);
        }
	}
}
