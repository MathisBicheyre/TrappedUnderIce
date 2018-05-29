using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class New_Game : MonoBehaviour
{
    public SSMPlayer script_SSMPlayer;
    public NavigatingMenus script_NavigatingMenus;

    private bool next;
    private int Menu_Current;

    public GameObject Menu_Changes;
    public Button button;

    public GameObject Menu_ChangingName;
    public TextMeshProUGUI Text_FirstName;
    public TextMeshProUGUI Text_LastName;
    public TextMeshProUGUI Text_Age;

    public GameObject Menu_ChangingStats;
    public Slider Slider_Health;
    public Slider Slider_SocialLife;
    public Slider Slider_Work;
    public TextMeshProUGUI Text_ResultHealth;
    public TextMeshProUGUI Text_ResultSocialLife;
    public TextMeshProUGUI Text_ResultWork;
    public TextMeshProUGUI Text_ResultTotal;

    public GameObject Menu_IntroducingScenario_1;
    public GameObject Menu_IntroducingScenario_2;
    public GameObject Menu_IntroducingScenario_3;
    public GameObject Menu_IntroducingScenario_4;


    void Activating_The_Button(bool X)
    {
        if (X) button.gameObject.SetActive(true);
        else button.gameObject.SetActive(false);
    }


    public DaysData script_DaysData;
    public void Next_Panel()
    {
        Menu_Current++;
        if (Menu_Current == 0)
        {
            Menu_ChangingName.SetActive(false);
            Menu_ChangingStats.SetActive(true);
            Debug.Log("Entering Menu_ChangingStats !!");
        }
        if (Menu_Current == 1)
        {
            script_SSMPlayer.Health.Change_value((int)(50 + Slider_Health.value));
            script_SSMPlayer.SocialLife.Change_value((int)(50 + Slider_SocialLife.value));
            script_SSMPlayer.Work.Change_value((int)(50 + Slider_Work.value));
            script_SSMPlayer.ChangeValue_Money((int)(1000 + Slider_Health.value - Slider_SocialLife.value + 2 * Slider_Work.value));

            Menu_ChangingStats.SetActive(false);
            Menu_Changes.SetActive(false);
            Menu_IntroducingScenario_1.SetActive(true);
            Debug.Log("Entering Menu_IntroducingScenario_1 !!");
        }
        if (Menu_Current == 2)
        {
            Menu_IntroducingScenario_1.SetActive(false);
            Menu_IntroducingScenario_2.SetActive(true);
            Debug.Log("Entering Menu_IntroducingScenario_2 !!");
        }
        if (Menu_Current == 3)
        {
            Menu_IntroducingScenario_2.SetActive(false);
            Menu_IntroducingScenario_3.SetActive(true);
            Debug.Log("Entering Menu_IntroducingScenario_3 !!");
        }
        if (Menu_Current == 4)
        {
            Menu_IntroducingScenario_3.SetActive(false);
            Menu_IntroducingScenario_4.SetActive(true);
            Debug.Log("Entering Menu_IntroducingScenario_4 !!");
        }
        if (Menu_Current == 5)
        {
            script_DaysData.Generating_Days();
            script_DaysData.Writing_Datas("Transition");

            Debug.Log("Entering a New Game !!");
            SceneManager.LoadScene("SSM_Scene_InGame");
        }
    }


    void Start()
    {
        script_SSMPlayer.Initialize_SSMPlayer();

        next = false;
        Menu_Current = -1;
        Menu_Changes.SetActive(true);
        Menu_ChangingName.SetActive(true);
        Menu_ChangingStats.SetActive(false);
        Menu_IntroducingScenario_1.SetActive(false);
        Menu_IntroducingScenario_2.SetActive(false);
        Menu_IntroducingScenario_3.SetActive(false);
        Menu_IntroducingScenario_4.SetActive(false);

        Slider_Health.value = 5;
        Slider_SocialLife.value = 5;
        Slider_Work.value = 5;
    }

    void Update()
    {
        if (Menu_Current == -1)
        {
            int X = 10;

            script_SSMPlayer.ChangeValue_FirstName(Text_FirstName.text);
            script_SSMPlayer.ChangeValue_LastName(Text_LastName.text);
            if (int.TryParse(Text_Age.text, out X)) script_SSMPlayer.ChangeValue_Age(int.Parse(Text_Age.text));

            Activating_The_Button(script_SSMPlayer.Display_FirstName().Length > 0
                && script_SSMPlayer.Display_LastName().Length > 0
                && script_SSMPlayer.Display_Age() >= 20
                && script_SSMPlayer.Display_Age() <= 80);
        }
        if (Menu_Current == 0)
        {
            Text_ResultHealth.text = Slider_Health.value.ToString();
            Text_ResultSocialLife.text = Slider_SocialLife.value.ToString();
            Text_ResultWork.text = Slider_Work.value.ToString();
            Text_ResultTotal.text = "Total : " + (Slider_Health.value + Slider_SocialLife.value + Slider_Work.value).ToString() + " / 15";

            Activating_The_Button(Slider_Health.value
                + Slider_SocialLife.value
                + Slider_Work.value == 15);
        }
        if (next == true && script_NavigatingMenus.IsInputCorrect()) Next_Panel();
        if (Menu_Current == 1) next = true;
    }
}