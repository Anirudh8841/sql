//!  A Gamecontroller script  
/*!
  Used for accessing the user input data and to respond according to the data
*/
using System.Collections;
using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//[RequireComponent(typeof(Button))]

public class Gamecontroller : MonoBehaviour
{
    /*! 
     * \var string s for displaying on the scrollview
     * \var bool errors storing if errors
     * \var string a contains the error statement or hint result  
     * \var string guesscheck for storing the given input in input field 
     * \var tick1,tick2,tick3.. are gameobjects created and are assigned to greentick in inspector block in unity 
     */
    string s = "SQL, Structured Query Language, is a programming language designed to manage data stored in relational databases." + "\n" +
       "Commands in sql are made mainly by these keywords SELECT,WHERE,AND ,OR,ORDER BY,UNION..etc " + "\n" + "some examples of commands in sql" + "\n"
        + "1.'SELECT * FROM table_name ;' selects all data from table" + "\n" +
        "2.'SELECT country,wins FROM scoreboard ;'   selects country name and no. of wins column from scoreboard table" +
        "\n"+ "Example for this :" + "\n" +
        "1.SELECT brand FROM pants WHERE brand = ParkAvenue ;"+"\n"+"This selects all pants whose brand name is ParkAvenue,also here commands are case sensitive and also maintain spaces between keywords";
    public bool errors;
    public string a,guesscheck;
    public string[] ansarray = new string[3] { "1", "2", "3" };
    public GameObject tick1, tick2, tick3, tick4, tick5;
    public List<string> ans = new List<string>();
    private InputField input;

    [SerializeField]
    private Text nerds = null;
    // \text nerds is a private text object created to change or access the text in scrollview 
    
    // \button these buttons are for changiing pants and shirts to the character on click 

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


// \var 2d string array used to store the table 

    string[][] pantArray = new string[][]
{
    new string[]        {"ParkAvenue", "Ironed","Yellow","1300"},
    new string[]        {"AllenSolly", "Notwashed","Black","800"},
    new string[]        {"PeterEngland","Ironed","Brown","1000" },
    new string[]        {"Raymond","NotIroned","Black","900" },
    new string[]        {"AllenSolly","Ironed","Purple","1100" }
};

    // \var int array used to store the costs in the table

    int[] carray = new int[] { 1300, 800, 1000, 900, 1100 };
    string[] pantcolor = new string[] { "Black", "Purple", "Brown", "Yellow" };
    int pnum;



    public Material dress;
    public Texture[] textures;
    private Texture onbody;
    private int num;
    private int shirtnum;
    private int pantnum;


    /** 
     * A normal member Start taking no arguments and returns nothing
     * This Start function is called when the coding ground scene is loaded.
     * In this function we are going to initialize the content in scrollview.
    */

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



    // pantsarray[0] = new string[4];
    // pantsarray[0] = new string[] { "Park Avenue", "Ironed","Light Blue","1300"};



    /** 
     * A  member Awake taking no arguments and returns nothing.
     * This Awake function is called whenever there is some change in the input field.
     * In this function we are going to find the text entered in the inputfield and storing it in a variable named input.
    */
    void Awake()
    {
        input = GameObject.Find("InputField").GetComponent<InputField>();

    }


    /** 
    * A member CheckWhere taking one argument and returns nothing.
    * @param substrings an array of strings arguement. 
    * This CheckWhere() function is called to check where in the entered input.
    * In this function we are going to find whether there is keyword where in input.
    * If there is Where then we read further unti; end and validate the array one by one according to Where based commands
    * We have done coding for keyword where with conditions based on brand,cost,condition for (=, < >)  but for and ,or we havent implemented but can be done if extended 
   */


    void CheckWhere(string[] substrings)            
    {
        // Commenting in detail for only brand case since all other cases will be similar

        if (substrings.Length >= 8)
        {
            if (substrings[5] == "brand" || substrings[5] == "BRAND")  // for condition based on brands
            {
                if (substrings[6] == "=")  // condition based on brand using equality symbol(=)
                {

                    bool b = false;
                    int i = 0;
                    List<int> myInts = new List<int>(); // intializing a list to add the index of valid and selected items based on condition

                    while (i < 5 && b == false)  //  checking equality for each element inn pantarray 
                    {
                        b = Array.Exists(pantArray[i], element => element == substrings[7]); // comparing to orginal brand

                        if (b == true)
                        {
                            myInts.Add(i); // if b = true adding corresponding pantarray index to the list

                            b = false;
                        }

                        i++;
                    }

                    int[] temparray = myInts.ToArray(); // storing  answers in an temporary array to 



                    if (myInts.Count > 0)
                    {
                        if (substrings[8] == ";" && substrings.Length == 9)
                        {
                            for (int l = 0; l < myInts.Count; l++)
                            {

                                ans.Add((temparray[l] + 1).ToString() + " " + pantArray[temparray[l]][0]);

                            }

                        }
                        else if (substrings[8] == "AND" || substrings[8] == "OR")
                        {
                            a = "Error: TO be implemented";
                            //Debug.Log("TO be implemented"); // and or case commands to be implemented
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

                else // Since for brand name there wont be greater and less than comparision 
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
                        b = Array.Exists(pantArray[i], element => element == substrings[7]); 

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
                                ans.Add((temparray[l] + 1).ToString() + " " + pantArray[temparray[l]][0]);
                                //  ans[l] = pantArray[temparray[l]][0];
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
                                ans.Add((temparray[l] + 1).ToString() + " " + pantArray[temparray[l]][0]);
                                // ans[l] = pantArray[temparray[l]][0];
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
                            ans.Add((temparray[l] + 1).ToString() + " " + pantArray[temparray[l]][0]);
                            // ans[l] = pantArray[temparray[l]][0];
                        }

                    }
                    else if (substrings[8] == "AND" || substrings[8] == "OR")
                    {
                        a = "Error: TO be implemented";
                        //  Debug.Log("TO be implemented"); 
                        // and or case commands
                    }
                    else
                    {
                        errors = true;
                        a = "Error: not a valid command or out of level";
                        
                    }
                }
                else
                {
                    errors = true;
                    a = "Error: near colour name";
                     //invalid condition 
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

    /** A normal member CheckSelect used to split and read each part of entered input code.
    *  @param substrings takes an array of string as arguement .
    *   Here we split and compare each part of code with available keywords and if no errors we proceed further for checkwhere and then evaluates the entered code
    */
    void CheckSelect(string[] substrings)          //comparing with SELECT commands
    {
        if (substrings[0] == "SELECT" && substrings[2] == "FROM")
        {
            if (substrings[1] == "brand")
            {
                if (substrings[3] == "pants" || substrings[3] == "pants;")
                {
                    if (substrings[3] == "pants")
                    {
                        if (substrings.Length >= 5)
                        {
                            if (substrings[4] == ";" && substrings.Length == 5)
                            {
                                //complete command case "SELECT * FROM pants ;"
                                for (int l = 0; l < 5; l++)
                                {
                                    ans.Add((l + 1).ToString() + " " + pantArray[l][0]);
                                    // ans[l] = pantArray[l][0];
                                }
                               // ans.Add("all pants");
                               
                            }
                            else
                            {
                                if (substrings[4] == "WHERE") //if the 4th substring entered is where then code has keyword where so we will send for validating by calling checkwhere(). 
                                {
                                    CheckWhere(substrings); //checking for where command
                                }

                            }
                        }
                        else
                        {
                            errors = true;
                            a = "Error: Hint ';' should be present at the end of any command";
                            
                        }


                    }
                    else
                    {
                        // complete command case "SELECT * FROM pants;"
                        for (int l = 0; l < 5; l++)
                        {
                            ans.Add((l + 1).ToString() + " " + pantArray[l][0]);
                            // ans[l] = pantArray[l][0];
                        }
                       // ans.Add("all pants");
                       
                    }




                }
                else if (substrings[3] == "shirts" || substrings[3] == "shirts;")
                {

                }
                else
                {
                    errors = true;
                    a = "Error: table name";
                    
                }
            }
        }
        else
        {
            errors = true;
            a = "Error: SELECT or FROM";
           
        }
    }



     /** A normal member GetInput used to read entered input code in the input field.
    * @param string guess the whole code entered in the input box
    * returns nothing but calls functions  like checkselect() for validating code on clicking enter. 
    */
    public void GetInput(string guess)
    {
        // on click intialising errors to false,clearing answers list ,a to null string,all the ticks to inactive with all elements in ansarray to none.

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
                // cases for setting green ticks to active state from the index of answers
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

               
            }
           
        }
        else
        {
            errors = true;

            a = "Error: Wrong Code,have a look at hint";
       
        }

        if (errors == false)
        {

            s = s + "\n" + guess;
            Callupdate(s, a);
            input.text = "";


        }
        else
        {
            // Debug.Log("enterd" + ansarray.Length);
           
            ansarray[4] = a;
           

            Callupdate(s, a);
        }


    }


    /** A normal member Callupdate used to update after entering input and clicking enter
   *  @param  r takes a string r as arguement for updating scrollview
   *  @param  r1 takes a string r1 as arguement for updating text in buttons displayed for changing pant and shirts.
   */


    public void Callupdate(string r, string r1)
    {

        nerds.text = r;

        mybutton1.GetComponentInChildren<Text>().text = ansarray[0];
        mybutton2.GetComponentInChildren<Text>().text = ansarray[1];
        mybutton3.GetComponentInChildren<Text>().text = ansarray[2];
        mybutton4.GetComponentInChildren<Text>().text = ansarray[3];
        mybutton5.GetComponentInChildren<Text>().text = ansarray[4];
       
    }

    /**  A normal member Compilecode used for Run button 
     *  Calls Getinput method written for functioning of run button,SO will have same functionality as pressing enter after entering input
     */
    public void Compilecode()
    {
        string st = "";
        GetInput(st);
    }

    /**  A normal member Onclickb1() used for changing texture on character from corresponding button's text.
    *  in this we intially written a for loop for finding out the present texture present on the body and then we mapped its index according to the new pnum and snums
    *  
    */

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

        pnum = pantnum;
        Callpnum(ansarray[0]);
        dress.mainTexture = textures[4 * shirtnum + pnum];


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
        pnum = pantnum;
        Callpnum(ansarray[1]);
        dress.mainTexture = textures[4 * shirtnum + pnum];

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
        pnum = pantnum;
        Callpnum(ansarray[2]);
        dress.mainTexture = textures[4 * shirtnum + pnum];

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
         
        pnum = pantnum;
        Callpnum(ansarray[3]);
        dress.mainTexture = textures[4 * shirtnum + pnum];

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
        
        pnum = pantnum;
        Callpnum(ansarray[4]);
        dress.mainTexture = textures[4 * shirtnum + pnum];


    }

    public GameObject display;
    public void Onbuttonclick6()
    {


        display.SetActive(false);

    }
    /**  A normal member Callpnum used for assigning the pnum ,snum according to the text displayed on the button 
     * @param dupbutton takes a string dupbutton as an arguement 
     * we assign snum and pnum according to dupbutton string and the order in which the colors and textures are made 
    */


    public void Callpnum(string dupbutton)
    {

        if (dupbutton == "None" || dupbutton == "Error:")
        {
            
        }
        else
        {
           
            if (dupbutton.Substring(0, 1) == "1")
            {
                pnum = 3;
               

            }
            else if (dupbutton.Substring(0, 1) == "2")
            {
                pnum = 0;
            }
            else if (dupbutton.Substring(0, 1) == "3")
            {
                pnum = 2;

            }
            else if (dupbutton.Substring(0, 1) == "4")
            {
                pnum = 0;
            }
            else if (dupbutton.Substring(0, 1) == "5")
            {
                pnum = 1;
            }
        }



    }

  
}


