using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class SSMPlayer : MonoBehaviour
{
    public class Stat_Element
    {
        private int value;
        private int bis;

        public Stat_Element(string S)
        {
            Debug.Log("We create a class *Stat_Element*, named " + S);
            value = 50;
            bis = 0;
        }

        ~Stat_Element()
        {
            Debug.Log("Destroying the class *Stat_Element*");
        }

        public int Display_value() { return value; }
        public int Display_bis() { return bis; }
        public void Change_value(int X) { value = X; }
        public void Change_bis(int X) { bis = X; }
    };

    const int MONEY_MAX = 3000;
    const int REPUTATION_MIN = 0;
    const int REPUTATION_MAX = 25;
    const int VALUE_MIN = 0;
    const int VALUE_MAX = 100;

    public Stat_Element Health;
    public Stat_Element SocialLife;
    public Stat_Element Work;

    static private int Money;
    static private int Reputation;
    static private string FirstName;
    static private string LastName;
    static private int Age;

    public int Display_Money() { return Money; }
    public int Display_Reputation() { return Reputation; }
    public string Display_FirstName() { return FirstName; }
    public string Display_LastName() { return LastName; }
    public int Display_Age() { return Age; }

    public void ChangeValue_Money(int X) { Money = X; }
    public void ChangeValue_Reputation(int X) { Reputation = X; }
    public void ChangeValue_FirstName(string X) { FirstName = X; }
    public void ChangeValue_LastName(string X) { LastName = X; }
    public void ChangeValue_Age(int X) { Age = X; }

    public void Initialize_SSMPlayer()
    {
        Debug.Log("We Initialize the Player's Stats");

        Health = new Stat_Element("Health");
        SocialLife = new Stat_Element("SocialLife");
        Work = new Stat_Element("Work");

        ChangeValue_Money(1000);
        ChangeValue_Reputation(10);
        ChangeValue_FirstName("John");
        ChangeValue_LastName("Doe");
        ChangeValue_Age(18);
    }

    public void Show_All_SSMPlayerStats()
    {
        Debug.Log("Displaying the Player's Stats");

        Debug.Log("Health : " + Health.Display_value());
        Debug.Log("SocialLife : " + SocialLife.Display_value());
        Debug.Log("Work : " + Work.Display_value());

        Debug.Log("Health - Bis : " + Health.Display_bis());
        Debug.Log("SocialLife - Bis : " + SocialLife.Display_bis());
        Debug.Log("Work - Bis : " + Work.Display_bis());

        Debug.Log("Money : " + Display_Money());
        Debug.Log("Reputation : " + Display_Reputation());
        Debug.Log("FirstName : " + Display_FirstName());
        Debug.Log("LastName : " + Display_LastName());
        Debug.Log("Age : " + Display_Age());
    }


    public InGame script_InGame;
    public DaysData script_DaysData;

    public void Apply_Stats_Changes(int X)
    {
        int TOUR = script_InGame.Display_Cpt_Tour() - 1;

        Health.Change_bis(script_DaysData.D[TOUR].Display_Values_Given(X, 0));
        Health.Change_value(Health.Display_value() + Health.Display_bis());

        SocialLife.Change_bis(script_DaysData.D[TOUR].Display_Values_Given(X, 1));
        SocialLife.Change_value(SocialLife.Display_value() + SocialLife.Display_bis());

        Work.Change_bis(script_DaysData.D[TOUR].Display_Values_Given(X, 2));
        Work.Change_value(Work.Display_value() + Work.Display_bis());

        ChangeValue_Money((int)(1.05 * (Display_Money() + script_DaysData.D[TOUR].Display_Values_Given(X, 3))));

        ChangeValue_Reputation(Display_Reputation() + script_DaysData.D[TOUR].Display_Values_Given(X, 4));

        if (Health.Display_value() > 100) Health.Change_value(100);
        if (SocialLife.Display_value() > 100) SocialLife.Change_value(100);
        if (Work.Display_value() > 100) Work.Change_value(100);
        script_InGame._Switch = true;
    }

    public int VictoryOrDefeat()
    {
        // WINNING
        if (Money >= MONEY_MAX
            || Reputation > +REPUTATION_MAX) return 0;

        // LOOSING
        if (Money <= 0
            || Reputation <= REPUTATION_MIN
            || Health.Display_value() <= 0
            || SocialLife.Display_value() <= 0
            || Work.Display_value() <= 0
            || script_InGame.Display_Cpt_Tour() == 30) return 1;

        // NOTHING
        return 2;
    }


    public NavigatingMenus script_NavigatingMenus;
    public GameObject Menu_ENDING;
    public TextMeshProUGUI blabla;
    public TextMeshProUGUI blabla_2;
    public TextMeshProUGUI blabla_3;
    public TextMeshProUGUI blabla_4;
    public TextMeshProUGUI blabla_5;
    public TextMeshProUGUI blabla_6;
    public TextMeshProUGUI blabla_7;

    public void The_End(int x)
    {
        Debug.Log("Enter the final score Display !!");
        Menu_ENDING.SetActive(true);

        blabla_2.text = "";
        if (x == 0)
        {
            blabla.text = "Victory !!";
            blabla.color = Color.green;

            if (Money >= MONEY_MAX)
            {
                blabla_2.gameObject.SetActive(true);
                blabla_2.text = "You bought the company !!\n";
            }
            else blabla_2.gameObject.SetActive(false);

            if (Reputation >= REPUTATION_MAX)
            {
                blabla_3.gameObject.SetActive(true);
                blabla_3.text = "You've been promoted CEO !!\n";
            }
            else blabla_3.gameObject.SetActive(false);
        }
        else
        {
            blabla.text = "Defeat ...";
            blabla.color = Color.red;
            if (Money <= 0)
            {
                blabla_2.gameObject.SetActive(true);
                blabla_2.text = "You went bankrupt ...\n";
            }
            else blabla_2.gameObject.SetActive(false);

            if (Reputation <= REPUTATION_MIN)
            {
                blabla_3.gameObject.SetActive(true);
                blabla_3.text = "You were expelled from the company : bad reputation ...\n";
            }
            else blabla_3.gameObject.SetActive(false);

            if (Health.Display_value() <= 0)
            {
                blabla_4.gameObject.SetActive(true);
                blabla_4.text = "You fell deeply sick ...\n";
            }
            else blabla_4.gameObject.SetActive(false);

            if (SocialLife.Display_value() <= 0)
            {
                blabla_5.gameObject.SetActive(true);
                blabla_5.text = "You fell into depression ...\n";
            }
            else blabla_5.gameObject.SetActive(false);

            if (Work.Display_value() <= 0)
            {
                blabla_6.gameObject.SetActive(true);
                blabla_6.text = "You were expelled from the company : not producing enough work ...\n";
            }
            else blabla_6.gameObject.SetActive(false);

            if (script_InGame.Display_Cpt_Tour() == 30)
            {
                blabla_7.gameObject.SetActive(true);
                blabla_7.text = "Your contract came to an end ...\n";
            }
            else blabla_7.gameObject.SetActive(false);
        }
    }


    //      Start && Update

    public void Start()
    {

    }

    public void Update()
    {

    }
}