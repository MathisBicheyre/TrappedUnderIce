using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class DaysData : MonoBehaviour
{
    public class Day
    {
        private string Day_Presentation;
        private int Number_Of_Choices;
        private string[] Choice;
        private int[,] Values_Needed;
        private int[,] Values_Given;

        /*
         * 0 - Health
         * 1 - Social Life
         * 2 - Work
         * 3 - Money
         * 4 - Reputation*/

        public Day(int X)
        {
            Debug.Log("We create a struct *Day* element, number " + X);
            Day_Presentation = "We have an emergency";
            Number_Of_Choices = 4;

            Dynamic_Alloc_Choice();
            Dynamic_Alloc_Values_Needed();
            Dynamic_Alloc_Values_Given();

            for (int i = 0; i < Number_Of_Choices; i++)
            {
                Choice[i] = " Proposing solution n° " + (i + 1).ToString();
                for (int j = 0; j < 5; j++)
                {
                    Values_Needed[i, j] = 0;
                    Values_Given[i, j] = 0;
                }
            }
        }

        ~Day() { Debug.Log("Destroying the class *Day*"); }

        public void Display_Day()
        {
            Debug.Log(Day_Presentation);
            Debug.Log("Number of Solutions :" + Number_Of_Choices);
            for (int i = 0; i < Number_Of_Choices; i++)
            {
                Debug.Log("Choice " + i + " : " + Choice[i]);
                for (int j = 0; j < 5; j++) Debug.Log(Values_Needed[i, j]);
                for (int j = 0; j < 5; j++) Debug.Log(Values_Given[i, j]);
            }
        }

        public void Set_Day_Presentation(string X) { Day_Presentation = X; }
        public void Set_Number_Of_Choices(int X) { Number_Of_Choices = X; }
        public void Set_Choice(string X, int Y) { Choice[Y] = X; }
        public void Set_Values_Needed(int X, int Y, int value) { Values_Needed[X, Y] = value; }
        public void Set_Values_Given(int X, int Y, int value) { Values_Given[X, Y] = value; }

        public void Dynamic_Alloc_Choice() { Choice = new string[Number_Of_Choices]; }
        public void Dynamic_Alloc_Values_Needed() { Values_Needed = new int[Number_Of_Choices, 5]; }
        public void Dynamic_Alloc_Values_Given() { Values_Given = new int[Number_Of_Choices, 5]; }

        public string Display_Day_Presentation() { return Day_Presentation; }
        public int Display_Number_Of_Choices() { return Number_Of_Choices; }
        public string Display_Choice(int X) { return Choice[X]; }
        public int Display_Values_Needed(int X, int Y) { return Values_Needed[X, Y]; }
        public int Display_Values_Given(int X, int Y) { return Values_Given[X, Y]; }
    };

    public InGame script_InGame;

    public Day[] D;
    static private int[,] myArray = new int[2, 30];
    private int cpt;


    // Loading Stuff- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

    public void Generating_Days()
    {
        int R;
        int max = 29;

        for (int i = 0; i < 30; i++) myArray[0, i] = i + 1;

        for (int i = 0; i < 30; i++)
        {
            R = Random.Range(0, max);
            // R = Random.RandomRange(0, max);

            myArray[1, i] = myArray[0, R];

            for (int x = R; x < 29; x++)
            {
                myArray[0, x] = myArray[0, x + 1];
            }

            max--;
        }
    } // If creating a New Game

    public void Loading_Days()
    {
        string[] lines;
        D = new Day[30];

        for (int i = 0; i < 30; i++)
        {
            D[i] = new Day(i);
            lines = System.IO.File.ReadAllLines("./Assets/SSM/days/" + myArray[1, i] + ".txt");

            //Ligne 0 - Description du jour
            cpt = 0;
            D[i].Set_Day_Presentation(Reading_String(lines[0]));

            //Ligne 1 - Nombre de choix possibles
            cpt = 0;
            D[i].Set_Number_Of_Choices(Reading_Value(lines[1]));
            D[i].Dynamic_Alloc_Choice();
            D[i].Dynamic_Alloc_Values_Needed();
            D[i].Dynamic_Alloc_Values_Given();

            //Ligne 2 à (2 + Nombre de choix possibles) - description du choix/stats demandées/stats modifiées
            for (int j = 0; j < D[i].Display_Number_Of_Choices(); j++)
            {
                cpt = 0;
                D[i].Set_Choice(Reading_String(lines[j + 2]), j);

                for (int k = 0; k < 5; k++) D[i].Set_Values_Needed(j, k, Reading_Value(lines[j + 2]));
                for (int k = 0; k < 5; k++) D[i].Set_Values_Given(j, k, Reading_Value(lines[j + 2]));
            }
        }
    }

    public string Reading_String(string S)
    {
        int cpt_local = 0;
        char[] Tampon_char = new char[200];

        while (S[cpt] != ';')
        {
            Tampon_char[cpt_local] = S[cpt];
            cpt++;
            cpt_local++;
        }
        Tampon_char[cpt_local++] = '\0';
        cpt++;

        return new string(Tampon_char);
    }

    public int Reading_Value(string S)
    {
        int cpt_local = 0;
        char[] Tampon_char = new char[10];

        while (S[cpt] != ';')
        {
            Tampon_char[cpt_local] = S[cpt];
            cpt++;
            cpt_local++;
        }
        Tampon_char[cpt_local++] = '\0';
        cpt++;

        string X = new string(Tampon_char);
        return int.Parse(X);
    }

    public void Loading_Text_File(string S)
    {
        script_SSMPlayer.Initialize_SSMPlayer();

        string[] lines = System.IO.File.ReadAllLines("./Assets/SSM/" + S + ".txt");

        cpt = 0; script_SSMPlayer.ChangeValue_FirstName(Reading_String(lines[0]));
        cpt = 0; script_SSMPlayer.ChangeValue_LastName(Reading_String(lines[1]));
        cpt = 0; script_SSMPlayer.ChangeValue_Age(Reading_Value(lines[2]));
        cpt = 0; script_SSMPlayer.ChangeValue_Money(Reading_Value(lines[3]));
        cpt = 0; script_SSMPlayer.ChangeValue_Reputation(Reading_Value(lines[4]));

        cpt = 0; script_SSMPlayer.Health.Change_value(Reading_Value(lines[5]));
        cpt = 0; script_SSMPlayer.Health.Change_bis(Reading_Value(lines[6]));

        cpt = 0; script_SSMPlayer.SocialLife.Change_value(Reading_Value(lines[7]));
        cpt = 0; script_SSMPlayer.SocialLife.Change_bis(Reading_Value(lines[8]));

        cpt = 0; script_SSMPlayer.Work.Change_value(Reading_Value(lines[9]));
        cpt = 0; script_SSMPlayer.Work.Change_bis(Reading_Value(lines[10]));

        cpt = 0; script_InGame.Set_Cpt_Tour(Reading_Value(lines[11]));
        for (int i = 0; i < 30; i++) { cpt = 0; myArray[1, i] = Reading_Value(lines[12 + i]); }
    }


    public void Writing_Datas(string S)
    {
        string[] lines = new string[42];
        char[] Tampon_char = new char[100];
        int cpt;

        for (cpt = 0; cpt < 20; cpt++)
        {
            if (script_SSMPlayer.Display_FirstName().Length > cpt) Tampon_char[cpt] = script_SSMPlayer.Display_FirstName()[cpt];
            else
            {
                Tampon_char[cpt] = '\0';
                break;
            }
        }
        Tampon_char[cpt++] = ';';
        Tampon_char[cpt++] = '\0';
        lines[0] = new string(Tampon_char);

        Tampon_char = new char[100];
        for (cpt = 0; cpt < 20; cpt++)
        {
            if (script_SSMPlayer.Display_LastName().Length > cpt) Tampon_char[cpt] = script_SSMPlayer.Display_LastName()[cpt];
            else
            {
                Tampon_char[cpt] = '\0';
                break;
            }
        }
        Tampon_char[cpt++] = ';';
        Tampon_char[cpt++] = '\0';
        lines[1] = new string(Tampon_char);

        lines[2] = script_SSMPlayer.Display_Age().ToString() + ";";
        lines[3] = script_SSMPlayer.Display_Money().ToString() + ";";
        lines[4] = script_SSMPlayer.Display_Reputation().ToString() + ";";

        lines[5] = script_SSMPlayer.Health.Display_value().ToString() + ";";
        lines[6] = script_SSMPlayer.Health.Display_bis().ToString() + ";";

        lines[7] = script_SSMPlayer.SocialLife.Display_value().ToString() + ";";
        lines[8] = script_SSMPlayer.SocialLife.Display_bis().ToString() + ";";

        lines[9] = script_SSMPlayer.Work.Display_value().ToString() + ";";
        lines[10] = script_SSMPlayer.Work.Display_bis().ToString() + ";";

        if (S == "Transition") lines[11] = "0;";
        else lines[11] = (script_InGame.Display_Cpt_Tour() - 1).ToString() + ";";

        for (int i = 0; i < 30; i++) lines[12 + i] = myArray[1, i].ToString() + ";";

        System.IO.File.WriteAllLines(@"./Assets/SSM/" + S + ".txt", lines);
    }
    // - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -


    private bool[] Available = new bool[4];
    public TextMeshProUGUI Description;

    public Button button_0;
    public Button button_1;
    public Button button_2;
    public Button button_3;

    public Button button_00;
    public Button button_11;
    public Button button_22;
    public Button button_33;

    public TextMeshProUGUI Choice_0;
    public TextMeshProUGUI Choice_1;
    public TextMeshProUGUI Choice_2;
    public TextMeshProUGUI Choice_3;

    public TextMeshProUGUI Choice_00;
    public TextMeshProUGUI Choice_11;
    public TextMeshProUGUI Choice_22;
    public TextMeshProUGUI Choice_33;

    public SSMPlayer script_SSMPlayer;

    public void Launching_A_Day()
    {
        IsAvailableOrNot();

        Description.text = D[script_InGame.Display_Cpt_Tour() - 1].Display_Day_Presentation();

        if (Available[0])
        {
            button_0.gameObject.SetActive(true);
            button_00.gameObject.SetActive(false);
            Choice_0.text = D[script_InGame.Display_Cpt_Tour() - 1].Display_Choice(0);
        }
        else
        {
            button_0.gameObject.SetActive(false);
            button_00.gameObject.SetActive(true);
            Choice_00.text = D[script_InGame.Display_Cpt_Tour() - 1].Display_Choice(0);
        }

        if (Available[1])
        {
            button_1.gameObject.SetActive(true);
            button_11.gameObject.SetActive(false);
            Choice_1.text = D[script_InGame.Display_Cpt_Tour() - 1].Display_Choice(1);
        }
        else
        {
            button_1.gameObject.SetActive(false);
            button_11.gameObject.SetActive(true);
            Choice_11.text = D[script_InGame.Display_Cpt_Tour() - 1].Display_Choice(1);
        }

        button_2.gameObject.SetActive(false);
        button_22.gameObject.SetActive(false);
        if (D[script_InGame.Display_Cpt_Tour() - 1].Display_Number_Of_Choices() > 2)
        {
            if (Available[2])
            {
                button_2.gameObject.SetActive(true);
                button_22.gameObject.SetActive(false);
                Choice_2.text = D[script_InGame.Display_Cpt_Tour() - 1].Display_Choice(2);
            }
            else
            {
                button_2.gameObject.SetActive(false);
                button_22.gameObject.SetActive(true);
                Choice_22.text = D[script_InGame.Display_Cpt_Tour() - 1].Display_Choice(2);
            }
        }


        button_3.gameObject.SetActive(false);
        button_33.gameObject.SetActive(false);
        if (D[script_InGame.Display_Cpt_Tour() - 1].Display_Number_Of_Choices() > 3)
        {
            if (Available[3])
            {
                button_3.gameObject.SetActive(true);
                button_33.gameObject.SetActive(false);
                Choice_3.text = D[script_InGame.Display_Cpt_Tour() - 1].Display_Choice(3);
            }
            else
            {
                button_3.gameObject.SetActive(false);
                button_33.gameObject.SetActive(true);
                Choice_33.text = D[script_InGame.Display_Cpt_Tour() - 1].Display_Choice(3);
            }
        }
    }

    public void IsAvailableOrNot()
    {
        int TOUR = script_InGame.Display_Cpt_Tour() - 1;

        for (int i = 0; i < D[TOUR].Display_Number_Of_Choices(); i++)
        {
            Available[i] = true;
            if (script_SSMPlayer.Health.Display_value() < D[TOUR].Display_Values_Needed(i, 0)) Available[i] = false;
            if (script_SSMPlayer.SocialLife.Display_value() < D[TOUR].Display_Values_Needed(i, 1)) Available[i] = false;
            if (script_SSMPlayer.Work.Display_value() < D[TOUR].Display_Values_Needed(i, 2)) Available[i] = false;
            if (script_SSMPlayer.Display_Money() < D[TOUR].Display_Values_Needed(i, 3)) Available[i] = false;
            if (script_SSMPlayer.Display_Reputation() < D[TOUR].Display_Values_Needed(i, 4)) Available[i] = false;
        }
    }


    // Use this for initialization
    void Start()
    {

    }

    public GameObject Menu_Loading;
    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "SSM_Scene_SavedGame")
        {
            if (Menu_Loading.activeInHierarchy)
            {
                Loading_Text_File("Save");
                Writing_Datas("Transition");
                Debug.Log("Entering the Saved Game !!");
                SceneManager.LoadScene("SSM_Scene_InGame");
            }
        }
    }
}
