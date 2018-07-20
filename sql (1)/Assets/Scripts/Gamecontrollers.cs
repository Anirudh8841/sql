using System.Collections;
using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//[RequireComponent(typeof(Button))]

public class Gamecontrollers : MonoBehaviour
{

    string s = "SQL, Structured Query Language, is a programming language designed to manage data stored in relational databases." + "\n" +
       "Commands in sql are made mainly by these keywords SELECT,WHERE,AND ,OR,ORDER BY,UNION..etc " + "\n" + "some examples of commands in sql" + "\n"
        + "1.'SELECT * FROM table_name ;' selects all data from table" + "\n" +
        "2.'SELECT country,wins FROM scoreboard ;'   selects country name and no. of wins column from scoreboard table" +
        "\n"+ "Example for this :" + "\n" +
        "1.SELECT brand FROM shirts WHERE brand = ParkAvenue ;"+"\n"+"This selects all shirts whose brand name is ParkAvenue,also here commands are case sensitive and also maintain spaces between keywords";
    public bool errors;
    public string a,guesscheck;
    public string[] ansarray = new string[3] { "1", "2", "3" };
    public GameObject tick1, tick2, tick3, tick4, tick5;
    // public GameObject pantimage, shirtimage;
    public List<string> ans = new List<string>();
    private InputField input;

    [SerializeField]
    private Text nerds = null;

    public Button mybutton1;
    public Button mybutton2;
    public Button mybutton3;
    public Button mybutton4;
    public Button mybutton5;
    public Button mybutton6;

    public bool clickd;
    //[SerializeField]
    //private Text nerdans = null;


    // Use this for initialization




    string[][] shirtArray = new string[][]
{
    new string[]        {"ParkAvenue", "Ironed","Green","990"},
    new string[]        {"AllenSolly", "Notwashed","Black","1100"},
    new string[]        {"PeterEngland","Ironed","White","1200" },
    new string[]        {"Raymond","NotIroned","Red","900" },
    new string[]        {"AllenSolly","Ironed","White","850" }
};

    int[] carray = new int[] { 990, 1100, 1200, 900, 850 };
    string[] shirtcolor = new string[] {  "Black", "Green", "Red" ,"White"};
    int pnum,snum;



    public Material dress;
    public Texture[] textures;
    private Texture onbody;
    private int num;
    private int shirtnum;
    private int pantnum;



    void Start()
    {


        nerds.text = s;
        //nerdans.text = null;

        // StartCoroutine(blink());




    }
    /* IEnumerator blink()
     {
         while (true)
         {
             tick.SetActive(false);
             yield return new WaitForSeconds(1.2f);
             tick.SetActive(true);
             yield return new WaitForSeconds(1.2f);

         }
     }
     */



    // shirtsarray[0] = new string[4];
    // shirtsarray[0] = new string[] { "Park Avenue", "Ironed","Light Blue","1300"};


    void Awake()
    {
        input = GameObject.Find("InputField").GetComponent<InputField>();

    }




    void CheckWhere(string[] substrings)            // comparing with SELECT and WHERE commands
    {
        if (substrings.Length >= 8)
        {
            if (substrings[5] == "brand" || substrings[5] == "BRAND")
            {
                if (substrings[6] == "=")
                {

                    bool b = false;
                    int i = 0;
                    List<int> myInts = new List<int>();

                    while (i < 5 && b == false)
                    {
                        b = Array.Exists(shirtArray[i], element => element == substrings[7]); // comparing to orginal name

                        if (b == true)
                        {
                            myInts.Add(i);

                            b = false;
                        }

                        i++;
                    }

                    int[] temparray = myInts.ToArray();



                    if (myInts.Count > 0)
                    {
                        if (substrings[8] == ";" && substrings.Length == 9)
                        {
                            for (int l = 0; l < myInts.Count; l++)
                            {

                                ans.Add((temparray[l] + 1).ToString() + " " + shirtArray[temparray[l]][0]);

                            }

                        }
                        else if (substrings[8] == "AND" || substrings[8] == "OR")
                        {
                            a = "Error: TO be implemented";
                            //Debug.Log("TO be implemented"); // and or case commands
                        }
                        else
                        {
                            errors = true;
                            a = "Error: not a valid command or out of level";
                            // Debug.Log("not a valid command or out of level");
                        }
                    }
                    else
                    {
                        errors = true;
                        a = "Error: brand name";

                        //Debug.Log("Error near brand name");  //invalid brand 
                    }


                }
                else
                {
                    errors = true;
                    a = "Error: near brand comparing hint use '=' ";
                    //Debug.Log("Error near brand comparing hint use '=' ");
                }
                // brand wise
            }
            else if (substrings[5] == "condition" || substrings[5] == "CONDITION")
            {
                if (substrings[6] == "=")
                {
                    bool b = false;
                    int i = 0;
                    List<int> myInts = new List<int>();

                    while (i < 5 && b == false)
                    {
                        b = Array.Exists(shirtArray[i], element => element == substrings[7]); // comparing to orginal name

                        if (b == true)
                        {
                            myInts.Add(i);
                            b = false;
                        }

                        i++;
                    }

                    var temparray = myInts.ToArray();

                    if (myInts.Count > 0)
                    {
                        if (substrings[8] == ";" && substrings.Length == 9)
                        {
                            for (int l = 0; l < myInts.Count; l++)
                            {
                                ans.Add((temparray[l] + 1).ToString() + " " + shirtArray[temparray[l]][0]);
                                //  ans[l] = shirtArray[temparray[l]][0];
                            }

                        }
                        else if (substrings[8] == "AND" || substrings[8] == "OR")
                        {
                            a = "Error: TO be implemented";
                            Debug.Log("TO be implemented"); // and or case commands
                        }
                        else
                        {
                            errors = true;
                            a = "Error: not a valid command or out of level";
                            //Debug.Log("not a valid command or out of level");
                        }
                    }
                    else
                    {
                        errors = true;
                        a = "Error: condition name";
                        //Debug.Log("Error near condition name");  //invalid condition 
                    }


                }
                else
                {
                    errors = true;
                    a = "Error: comparing error hint use '=' ";
                    //Debug.Log("Error near condition comparing hint use '=' ");
                }
                //condition wise
            }
            else if (substrings[5] == "colour" || substrings[5] == "COLOUR")
            {
                if (substrings[6] == "=")
                {
                    bool b = false;
                    int i = 0;
                    List<int> myInts = new List<int>();

                    while (i < 5 && b == false)
                    {
                        b = Array.Exists(shirtArray[i], element => element == substrings[7]); // comparing to orginal name

                        if (b == true)
                        {
                            myInts.Add(i);
                            b = false;
                        }

                        i++;
                    }

                    var temparray = myInts.ToArray();

                    if (myInts.Count > 0)
                    {
                        if (substrings[8] == ";" && substrings.Length == 9)
                        {
                            for (int l = 0; l < myInts.Count; l++)
                            {
                                ans.Add((temparray[l] + 1).ToString() + " " + shirtArray[temparray[l]][0]);
                                // ans[l] = shirtArray[temparray[l]][0];
                            }

                        }
                        else if (substrings[8] == "AND" || substrings[8] == "OR")
                        {

                            a = "Error: TO be implemented";
                            //Debug.Log("TO be implemented"); // and or case commands
                        }
                        else
                        {
                            errors = true;
                            a = "Error: not a valid command or out of level";
                            //Debug.Log("not a valid command or out of level");
                        }
                    }
                    else
                    {
                        errors = true;
                        a = "Error: colour name";
                        //Debug.Log("Error near colour name");  //invalid condition 
                    }


                }
                else
                {
                    errors = true;
                    a = "Error:  colour comparing hint use '='";
                    //Debug.Log("Error near colour comparing hint use '=' ");
                }
                //colour wise
            }

            else if (substrings[5] == "cost" || substrings[5] == "COST")
            {
                int i = 0;
                List<int> myInts = new List<int>();
                int num = Int32.Parse(substrings[7]);

                while (i < 5)
                {
                    if (substrings[6] == "=")
                    {
                        if (carray[i] == num)
                        {
                            myInts.Add(i);
                        }
                        i++;
                    }
                    else if (substrings[6] == ">")
                    {
                        if (carray[i] > num)
                        {
                            myInts.Add(i);
                        }
                        i++;
                    }
                    else if (substrings[6] == "<")
                    {
                        if (carray[i] < num)
                        {
                            myInts.Add(i);
                        }
                        i++;
                    }
                    else if (substrings[6] == "<=" || substrings[6] == "=<")
                    {
                        if (carray[i] <= num)
                        {
                            myInts.Add(i);
                        }
                        i++;
                    }
                    else if (substrings[6] == ">=" || substrings[6] == "=>")
                    {
                        if (carray[i] >= num)
                        {
                            myInts.Add(i);
                        }
                        i++;
                    }

                }

                var temparray = myInts.ToArray();

                if (myInts.Count > 0)
                {
                    if (substrings[8] == ";" && substrings.Length == 9)
                    {
                        for (int l = 0; l < myInts.Count; l++)
                        {
                            ans.Add((temparray[l] + 1).ToString() + " " + shirtArray[temparray[l]][0]);
                            // ans[l] = shirtArray[temparray[l]][0];
                        }

                    }
                    else if (substrings[8] == "AND" || substrings[8] == "OR")
                    {
                        a = "Error: TO be implemented";
                        //  Debug.Log("TO be implemented"); // and or case commands
                    }
                    else
                    {
                        errors = true;
                        a = "Error: not a valid command or out of level";
                        //    Debug.Log("not a valid command or out of level");
                    }
                }
                else
                {
                    errors = true;
                    a = "Error: near colour name";
                    //    Debug.Log("Error near colour name");  //invalid condition 
                }


                //cost wise
            }
            else
            {

            }
        }
        else
        {
            // incomplete after where  
        }


    }

    void CheckSelect(string[] substrings)          //comparing with SELECT commands
    {
        if (substrings[0] == "SELECT" && substrings[2] == "FROM")
        {
            if (substrings[1] == "brand")
            {
                if (substrings[3] == "shirts" || substrings[3] == "shirts;")
                {
                    if (substrings[3] == "shirts")
                    {
                        if (substrings.Length >= 5)
                        {
                            if (substrings[4] == ";" && substrings.Length == 5)
                            {

                                for (int l = 0; l < 5; l++)
                                {
                                    ans.Add((l + 1).ToString() + " " + shirtArray[l][0]);
                                    // ans[l] = shirtArray[l][0];
                                }
                               // ans.Add("all shirts");
                                //complete command case "SELECT * FROM shirts ;"
                            }
                            else
                            {
                                if (substrings[4] == "WHERE")
                                {
                                    CheckWhere(substrings); //checking for where command
                                }

                            }
                        }
                        else
                        {
                            errors = true;
                            a = "Error: Hint ';' should be present at the end of any command";
                            //Debug.Log("Syntax error,Hint ';' should be present at the end of any command");
                        }


                    }
                    else
                    {
                        for (int l = 0; l < 5; l++)
                        {
                            ans.Add((l + 1).ToString() + " " + shirtArray[l][0]);
                            // ans[l] = shirtArray[l][0];
                        }
                       // ans.Add("all shirts");
                        // complete command case "SELECT * FROM shirts;"
                    }




                }
                else if (substrings[3] == "shirts" || substrings[3] == "shirts;")
                {

                }
                else
                {
                    errors = true;
                    a = "Error: table name";
                    //Debug.Log("Error near table name");
                }
            }
        }
        else
        {
            errors = true;
            a = "Error: SELECT or FROM";
            //Debug.Log("Error near SELECT or FROM");
        }
    }

    public void GetInput(string guess)
    {
        guesscheck = guess;
        errors = false;
        ans.Clear();
        a = "";
        ansarray = new string[5];
        ansarray[0] = "None";
        ansarray[1] = "None";
        ansarray[2] = "None";
        ansarray[3] = "None";
        ansarray[4] = "None";
        tick1.SetActive(false);
        tick2.SetActive(false);
        tick3.SetActive(false);
        tick4.SetActive(false);
        tick5.SetActive(false);


        string[] subs = guess.Split(' ');  //splitting the input code by spaces 

        if (subs.Length >= 4)
        {
            CheckSelect(subs);
            string[] dup;
            dup = ans.ToArray();

            for (int i = 0; i < dup.Length; i++)
            {
                ansarray[i] = dup[i];
            }


            for (int i = 0; i < ansarray.Length; i++)
            {
                if (ansarray[i].Substring(0, 1) == "1")
                {
                    tick1.SetActive(true);
                }
                else if (ansarray[i].Substring(0, 1) == "2")
                {
                    tick2.SetActive(true);
                }
                else if (ansarray[i].Substring(0, 1) == "3")
                {
                    tick3.SetActive(true);
                }
                else if (ansarray[i].Substring(0, 1) == "4")
                {
                    tick4.SetActive(true);

                }
                else if (ansarray[i].Substring(0, 1) == "5")
                {
                    tick5.SetActive(true);
                }
                a = a + "\n" + ansarray[i];

                //Debug.Log("answer " + ansarray[i]);
            }
            // Debug.Log("answer  length "+ ansarray.Length);
        }
        else
        {
            errors = true;

            a = "Error: Wrong Code,have a look at hint";
            //   Debug.Log("Wrong Code,have a look at hint");
            //  Debug.Log("enterd" + ansarray.Length);
        }

        if (errors == false)
        {

            s = s + "\n" + guess;
            Callupdate(s, a);
            //Start();
            input.text = "";
            //nerdans.text = "";
            // tick.SetActive(true);

        }
        else
        {
            // Debug.Log("enterd" + ansarray.Length);
           
            ansarray[4] = a;
           

            Callupdate(s, a);
        }




        //   s = s + " \n "+ guess;
        // Debug.Log("string s " + s + "string t" + t);
        //  input.text = "";

    }

    public void Callupdate(string r, string r1)
    {

        // mybutton.image.overrideSprite = blockA;
        //

        // nerdans.text = r1;
        nerds.text = r;

        mybutton1.GetComponentInChildren<Text>().text = ansarray[0];
       // Debug.Log("button check" + mybutton1.GetComponentInChildren<Text>().text);
        mybutton2.GetComponentInChildren<Text>().text = ansarray[1];
        mybutton3.GetComponentInChildren<Text>().text = ansarray[2];
        mybutton4.GetComponentInChildren<Text>().text = ansarray[3];
        mybutton5.GetComponentInChildren<Text>().text = ansarray[4];
        // Onclickb1();
    }

    public void Compilecode()
    {
        string st = "";
        GetInput(st);
    }



    public void Onclickb1()
    {
        clickd = true;

        onbody = dress.GetTexture("_MainTex");
        for (int i = 0; i < 16; i++)
        {
            if (textures[i] == onbody)
            {
                num = i;
                i = 16;
            }
        }
        shirtnum = num / 4;
        pantnum = num % 4;
        // Debug.Log("shirtnum" + shirtnum + "\n" + "pantnum" + pantnum);
        pnum = pantnum;
        snum = shirtnum;
        Callpnum(ansarray[0]);
        dress.mainTexture = textures[4 * snum + pnum];


    }
    public void Onclickb2()
    {
        onbody = dress.GetTexture("_MainTex");
        for (int i = 0; i < 16; i++)
        {
            if (textures[i] == onbody)
            {
                num = i;
                i = 16;
            }
        }
        shirtnum = num / 4;
        pantnum = num % 4;
        // Debug.Log("shirtnum" + shirtnum + "\n" + "pantnum" + pantnum);
        pnum = pantnum;
        snum = shirtnum;
        Callpnum(ansarray[1]);
        dress.mainTexture = textures[4 * snum + pnum];


    }
    public void Onclickb3()
    {
        onbody = dress.GetTexture("_MainTex");
        for (int i = 0; i < 16; i++)
        {
            if (textures[i] == onbody)
            {
                num = i;
                i = 16;
            }
        }
        shirtnum = num / 4;
        pantnum = num % 4;
        // Debug.Log("shirtnum" + shirtnum + "\n" + "pantnum" + pantnum);
        pnum = pantnum;
        snum = shirtnum;
        Callpnum(ansarray[2]);
        dress.mainTexture = textures[4 * snum + pnum];


    }

    public void Onclickb4()
    {
        onbody = dress.GetTexture("_MainTex");
        for (int i = 0; i < 16; i++)
        {
            if (textures[i] == onbody)
            {
                num = i;
                i = 16;
            }
        }
        shirtnum = num / 4;
        pantnum = num % 4;
         Debug.Log(ansarray[3]);
        pnum = pantnum;
        snum = shirtnum;
        Callpnum(ansarray[3]);
        dress.mainTexture = textures[4 * snum + pnum];


    }
    public void Onclickb5()
    {
        onbody = dress.GetTexture("_MainTex");
        for (int i = 0; i < 16; i++)
        {
            if (textures[i] == onbody)
            {
                num = i;
                i = 16;
            }
        }
        shirtnum = num / 4;
        pantnum = num % 4;
        // Debug.Log("shirtnum" + shirtnum + "\n" + "pantnum" + pantnum);
        pnum = pantnum;
        snum = shirtnum;
        Callpnum(ansarray[4]);
        dress.mainTexture = textures[4 * snum + pnum];


    }

    public GameObject display;
    public void Onbuttonclick6()
    {


        display.SetActive(false);

    }



    public void Callpnum(string dupbutton)
    {

        if (dupbutton == "None" || dupbutton == "Error:")
        {
            
        }
        else
        {
            Debug.Log("entered0");
            if (dupbutton.Substring(0, 1) == "1")
            {
                snum = 1;
                Debug.Log("dup" + dupbutton.Substring(0, 1) + "dupwhole" + dupbutton);

            }
            else if (dupbutton.Substring(0, 1) == "2")
            {
                snum = 0;
            }
            else if (dupbutton.Substring(0, 1) == "3")
            {
                snum = 3;

            }
            else if (dupbutton.Substring(0, 1) == "4")
            {
                snum = 2;
            }
            else if (dupbutton.Substring(0, 1) == "5")
            {
                snum = 3;
            }
        }



    }

  
}


