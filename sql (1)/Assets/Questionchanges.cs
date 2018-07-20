using System.Collections;
using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class Questionchanges : MonoBehaviour {

    //[SerializeField]
    //public Text pques = null;

    public Button nextbutton;

    public TextMeshProUGUI pques;
   

    public string[] ques = new string[5] {
        "Select all shirt and try each of them",
        "Select All Ironed shirt and try one of them" ,
        "Select shirt whose price is above 1000rs and try one of them",
        "Select all shirt from Allensolly brand and try one of them",
        "Select all black coloured shirt and try one of them" };

    

    // Use this for initialization
    void Start ()
    {
       
        pques.SetText(ques[0]);



    }
	
 
    public void Qchange()
    {
        Gamecontroller g = FindObjectOfType<Gamecontroller>();

        if (pques.text == ques[0])
        {
           
            if (g.guesscheck == "SELECT brand FROM shirt ;") 
            {
                pques.text = ques[1];
            }

         }
        else if (pques.text == ques[1])
        {
            
            if (g.guesscheck == "SELECT brand FROM shirt WHERE condition = Ironed ;")
            {
                pques.text = ques[2];
            }

        }
        else if (pques.text == ques[2])
        {
            Debug.Log("ENtered 2 " + pques.text);
            if (g.guesscheck == "SELECT brand FROM shirt WHERE cost > 1000 ;")
            {
                pques.text = ques[3];
            }

        }
        else if (pques.text == ques[3])
        {
            Debug.Log("ENtered 3 " + pques.text);
            if (g.guesscheck == "SELECT brand FROM shirt WHERE brand = AllenSolly ;")
            {
                pques.text = ques[4];
          
            }

        }
        else if (pques.text == ques[4])
        {
            Debug.Log("ENtered 4 " + pques.text);
            if (g.guesscheck == "SELECT brand FROM shirt ;" )
            {
                pques.text = "Well Done";
            }

        }
    }
	// Update is called once per frame
	void Update ()
    {
       // Qchange();

	}
}
