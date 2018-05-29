using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class InGame : MonoBehaviour
{
    public bool _Switch;
    public SSMPlayer script_SSMPlayer;
    public NavigatingMenus script_NavigatingMenus;
    public DaysData script_DaysData;
    
    static private int Cpt_Tour;
    public int Display_Cpt_Tour() { return Cpt_Tour; }
    public void Set_Cpt_Tour(int X) { Cpt_Tour = X; }

    //EVERYTHING ABOUT A GAME
    public GameObject Menu_NewTurn;
    public GameObject Menu_Game;
    public GameObject Menu_Pause;
    public GameObject UI_Ojects;
    public GameObject UI_Days;

    // LAUCHING A NEW TURN
    public TextMeshProUGUI TextUGUI_Turn;
    public TextMeshProUGUI TextUGUI_FirstName;
    public TextMeshProUGUI TextUGUI_LastName;
    public TextMeshProUGUI TextUGUI_Age;
    public TextMeshProUGUI TextUGUI_Health;
    public TextMeshProUGUI TextUGUI_SocialLife;
    public TextMeshProUGUI TextUGUI_Work;


    // WITHIN A GAME
    public Slider Slider_Health;
    public Slider Slider_SocialLife;
    public Slider Slider_Work;
    public TextMeshProUGUI Text_Money;

    // WHEN LAUCHING A DAY

    public void Beginning_New_Turn()
    {
        _Switch = false;
        Cpt_Tour++;
        Debug.Log("Entering the New Turn Menu (inGame) !!");
        Menu_NewTurn.SetActive(true);
        Menu_Game.SetActive(false);

        TextUGUI_Turn.text = "Turn n° " + Cpt_Tour.ToString();
        TextUGUI_FirstName.text = script_SSMPlayer.Display_FirstName();
        TextUGUI_LastName.text = script_SSMPlayer.Display_LastName();
        TextUGUI_Age.text = script_SSMPlayer.Display_Age().ToString();

        TextUGUI_Health.text = script_SSMPlayer.Health.Display_bis().ToString();
        TextUGUI_SocialLife.text = script_SSMPlayer.SocialLife.Display_bis().ToString();
        TextUGUI_Work.text = script_SSMPlayer.Work.Display_bis().ToString();
    }

    public void New_Turn()
    {
        Menu_NewTurn.SetActive(false);
        Menu_Game.SetActive(true);
        UI_Days.SetActive(false);
        Debug.Log("Entering the Game Menu (inGame) !!");
        StartCoroutine(Filling_Bars());
        script_DaysData.Launching_A_Day();
    }

    public IEnumerator Filling_Bars()
    {
        int max;
        Text_Money.text = script_SSMPlayer.Display_Money().ToString() + " $";

        if (script_SSMPlayer.Health.Display_value() > script_SSMPlayer.SocialLife.Display_value() && script_SSMPlayer.Health.Display_value() > script_SSMPlayer.Work.Display_value()) max = script_SSMPlayer.Health.Display_value();
        else if (script_SSMPlayer.SocialLife.Display_value() > script_SSMPlayer.Health.Display_value() && script_SSMPlayer.SocialLife.Display_value() > script_SSMPlayer.Work.Display_value()) max = script_SSMPlayer.SocialLife.Display_value();
        else max = script_SSMPlayer.Work.Display_value();

        for (int i = 0; i <= max; i++)
        {
            if (i <= script_SSMPlayer.Health.Display_value()) Slider_Health.value = i;
            if (i <= script_SSMPlayer.SocialLife.Display_value()) Slider_SocialLife.value = i;
            if (i <= script_SSMPlayer.Work.Display_value()) Slider_Work.value = i;
            yield return new WaitForSeconds(0.009f);
        }
        UI_Days.SetActive(true);
    }

    // Use this for initialization
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "SSM_Scene_InGame")
        {
            script_DaysData.Loading_Text_File("Transition");
            script_DaysData.Loading_Days();
            script_SSMPlayer.Show_All_SSMPlayerStats();

            Menu_Pause.SetActive(false);
            Beginning_New_Turn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "SSM_Scene_InGame")
        {
            int x;

            if (Menu_NewTurn.activeInHierarchy && script_NavigatingMenus.IsInputCorrect()) New_Turn();

            if (_Switch == true)
            {
                if ((x = script_SSMPlayer.VictoryOrDefeat()) == 2) Beginning_New_Turn();
                else
                {
                    Menu_Game.SetActive(false);
                    script_SSMPlayer.The_End(x);
                }
            }
            if (Menu_Game.activeInHierarchy && Input.GetKeyUp(KeyCode.Escape))
            {
                Menu_Game.SetActive(false);
                Menu_Pause.SetActive(true);
            }
            if (Menu_Game.activeInHierarchy && Input.GetKeyUp(KeyCode.Tab))
            {
                UI_Ojects.SetActive(!UI_Ojects.activeInHierarchy);
                UI_Days.SetActive(!UI_Days.activeInHierarchy);
            }
        }
    }
}
