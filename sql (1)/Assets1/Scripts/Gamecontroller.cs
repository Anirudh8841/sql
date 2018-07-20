using System.Collections;
using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

//[RequireComponent(typeof(Button))]

public class Gamecontroller : MonoBehaviour {

    string s = "SQL, Structured Query Language, is a programming language designed to manage data stored in relational databases." + "\n" +
       "Commands in sql are made mainly by these keywords SELECT,WHERE,AND ,OR,ORDER BY,UNION..etc and all the keywords should be in capital letters" + "\n" + "some examples of commands in sql" + "\n"
        + "1.'SELECT * FROM table_name ;' selects all data from table" + "\n" +  
        "2.'SELECT country,wins FROM scoreboard ;'   selects country name and no. of wins column from scoreboard table" + "\n" + 
        "3.'SELECT * FROM countries WHERE name = India ;'   selects India from all countries list";

    public bool errors;
    public string a;
    public GameObject tick1,tick2,tick3,tick4,tick5;

   // public Button mybutton;

    //public Sprite blockA;
    //public Sprite blockB;


    public List<string> ans = new List<string>();
    

    private InputField input;



    [SerializeField]
    private Text nerds = null;
    [SerializeField]
    private Text nerdans = null;


    // Use this for initialization




    string[][] pantArray = new string[][]
{
    new string[]        {"ParkAvenue", "Ironed","Yellow","1300"},
    new string[]        {"AllenSolly", "Notwashed","Black","800"},
    new string[]        {"PeterEngland","Ironed","Brown","1000" },
    new string[]        {"Raymond","NotIroned","Black","900" },
    new string[]        {"AllenSolly","Ironed","Purple","1100" }
};

    int[] carray = new int[] { 1300, 800, 1000, 900, 1100 };

    void Start()
    {
       // mybutton = GetComponent<Button>();
        //Sprite blockA = Resources.Load("Spaceship_10", typeof(Sprite)) as Sprite;
        nerds.text = s ;
        nerdans.text = null;
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
    

 
    // pantsarray[0] = new string[4];
    // pantsarray[0] = new string[] { "Park Avenue", "Ironed","Light Blue","1300"};


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
                        b = Array.Exists(pantArray[i], element => element == substrings[7]); // comparing to orginal name

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
                         
                                ans.Add((temparray[l]+1).ToString()+" "+pantArray[temparray[l]][0]);
                           
                            }

                        }
                        else if (substrings[8] == "AND" || substrings[8] == "OR")
                        {
                            a = "TO be implemented";
                            //Debug.Log("TO be implemented"); // and or case commands
                        }
                        else
                        {
                            errors = true;
                            a = "not a valid command or out of level";
                           // Debug.Log("not a valid command or out of level");
                        }
                    }
                    else
                    {
                        errors = true;
                        a = "Error near brand name";

                        //Debug.Log("Error near brand name");  //invalid brand 
                    }


                }
                else
                {
                    errors = true;
                    a = "Error near brand comparing hint use '=' ";
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
                    b = Array.Exists(pantArray[i], element => element == substrings[7]); // comparing to orginal name

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
                                ans.Add((temparray[l] + 1).ToString() + " "+pantArray[temparray[l]][0]);
                                //  ans[l] = pantArray[temparray[l]][0];
                            }

                    }
                    else if (substrings[8] == "AND" || substrings[8] == "OR")
                    {
                            a = "TO be implemented";
                        Debug.Log("TO be implemented"); // and or case commands
                    }
                    else
                    {
                            errors = true;
                            a = "not a valid command or out of level";
                            //Debug.Log("not a valid command or out of level");
                    }
                }
                else
                {
                        errors = true;
                        a = "Error near condition name";
                        //Debug.Log("Error near condition name");  //invalid condition 
                }


            }
            else
            {
                    errors = true;
                    a = "Error near condition comparing hint use '=' ";
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
                    b = Array.Exists(pantArray[i], element => element == substrings[7]); // comparing to orginal name

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
                                ans.Add((temparray[l] + 1).ToString() + " "+pantArray[temparray[l]][0]);
                                // ans[l] = pantArray[temparray[l]][0];
                            }

                    }
                    else if (substrings[8] == "AND" || substrings[8] == "OR")
                    {

                            a = "TO be implemented";
                        //Debug.Log("TO be implemented"); // and or case commands
                    }
                    else
                    {
                            errors = true;
                            a = "not a valid command or out of level";
                            //Debug.Log("not a valid command or out of level");
                    }
                }
                else
                {
                        errors = true;
                        a = "Error near colour name";
                        //Debug.Log("Error near colour name");  //invalid condition 
                }


            }
            else
            {
                    errors = true;
                    a = "Error near colour comparing hint use '='";
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
                        else if(substrings[6] == ">")
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
                                ans.Add((temparray[l] + 1).ToString() + " "+pantArray[temparray[l]][0]);
                                // ans[l] = pantArray[temparray[l]][0];
                            }

                        }
                        else if (substrings[8] == "AND" || substrings[8] == "OR")
                        {
                        a = "TO be implemented";
                          //  Debug.Log("TO be implemented"); // and or case commands
                        }
                        else
                        {
                            errors = true;
                        a = "not a valid command or out of level";
                        //    Debug.Log("not a valid command or out of level");
                        }
                    }
                    else
                    {
                        errors = true;
                    a = "Error near colour name";
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
            if (substrings[1] == "*")
            {
                if (substrings[3] == "pants" || substrings[3] == "pants;")
                {
                    if(substrings[3] == "pants")
                    {
                        if (substrings.Length >= 5)
                        {
                            if (substrings[4] == ";" && substrings.Length == 5)
                            {
                                ans.Add("all pants");
                                  //complete command case "SELECT * FROM pants ;"
                            }
                            else
                            {
                                if(substrings[4] == "WHERE")
                                {
                                    CheckWhere(substrings); //checking for where command
                                }

                            }
                        }
                        else
                        {
                            errors = true;
                            a = "Syntax error,Hint ';' should be present at the end of any command";
                            //Debug.Log("Syntax error,Hint ';' should be present at the end of any command");
                        }


                    }
                    else
                    {
                        ans.Add("all pants");
                       // complete command case "SELECT * FROM pants;"
                    }
                   


                  
                }
                else if (substrings[3] == "shirts" || substrings[3] == "shirts;")
                {
                   
                }
                else
                {
                    errors = true;
                    a = "Error near table name";
                    //Debug.Log("Error near table name");
                }
            }
        }
        else
        {
            errors = true;
            a= "Error near SELECT or FROM";
            //Debug.Log("Error near SELECT or FROM");
        }
    }

 public void GetInput(string guess) 
    {
       
        errors = false;
        ans.Clear();
        a = "";
        tick1.SetActive(false);
        tick2.SetActive(false);
        tick3.SetActive(false);
        tick4.SetActive(false);
        tick5.SetActive(false);


        string[] subs = guess.Split(' ');  //splitting the input code by spaces 

        if (subs.Length >= 4)
        {
            CheckSelect(subs);
            string[] ansarray = ans.ToArray();

            for(int i = 0; i< ansarray.Length; i++)
            {
                if(ansarray[i].Substring(0,1) == "1")
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
                a = a + " \n " + ansarray[i];

                //Debug.Log("answer " + ansarray[i]);
            }
             Debug.Log("answer  length "+ ansarray.Length);
        }
        else
        {
            errors = true;
            a = "Wrong Code,have a look at hint";
            //Debug.Log("Wrong Code,have a look at hint" + subs.Length);
        }

        if (errors == false)
        {
           
            s = s + "\n" + guess;
            Callupdate(s,a);
            //Start();
            input.text = "";
            //nerdans.text = "";
           // tick.SetActive(true);
           
        }
        else
        {
            
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
      
        nerdans.text = r1;
        nerds.text = r;

    }
 public void Compilecode()
    {
        string st = "";
        GetInput(st);
    }

   


}
