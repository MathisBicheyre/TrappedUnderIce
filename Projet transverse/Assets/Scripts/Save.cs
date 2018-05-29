using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Save : MonoBehaviour
{

    private bool[] X = new bool[3];


    private void Read_The_Save()
    {
        string line = System.IO.File.ReadAllText("./Assets/save.txt");
        Debug.Log(line);

        for (int i = 0; i < 3; i++)
        {
            if (line[i] == 49) X[i] = true;
            else X[i] = false;
        }
    }


    public void Update_The_Save(int UPDATED)
    {
        char[] Tampon_char = new char[4];

        Read_The_Save();
        for (int i = 0; i < 3; i++)
        {
            if (X[i] == true) Tampon_char[i] = '1';
            else Tampon_char[i] = '0';
        }

        if (UPDATED != -1) Tampon_char[UPDATED] = '1';
        else
        {
            Tampon_char[0] = '0';
            Tampon_char[1] = '0';
            Tampon_char[2] = '0';
        }
        Tampon_char[3] = '\0';

        System.IO.File.WriteAllText(@"./Assets/save.txt", new string(Tampon_char));
    }


    public GameObject Door_Abyss;
    public GameObject Door_Cetacean;
    public GameObject Door_Hydro;
    public GameObject Door_Observatory;

    // Use this for initialization
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "NextLevel")
        {
            Read_The_Save();

            if (X[0]) Door_Abyss.SetActive(false);
            else Door_Abyss.SetActive(true);

            if (X[1]) Door_Cetacean.SetActive(false);
            else Door_Cetacean.SetActive(true);

            if (X[2]) Door_Hydro.SetActive(false);
            else Door_Hydro.SetActive(true);

            if (X[0] && X[1] && X[2]) Door_Observatory.SetActive(true);
            else Door_Observatory.SetActive(false);
            // Rendre les portes actives
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
