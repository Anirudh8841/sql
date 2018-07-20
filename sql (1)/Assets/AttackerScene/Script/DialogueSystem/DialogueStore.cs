using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueStore : MonoBehaviour {


    public HashText introResponse;

    public HashText[] hashLib;
	// Use this for initialization
	void Start () {
        introResponse = new HashText();
        introResponse.hash = 31;
        introResponse.content = "Nothing to talk";
        //could be extended
        hashLib = new HashText[7];
        for (int i = 0; i < hashLib.Length; i++)
        {
            hashLib[i] = new HashText();
        }
        hashLib[0].hash = 0;
        hashLib[0].content = "See you later";

        hashLib[1].hash = 10;
        hashLib[1].content = "I am Raja";

        hashLib[2].hash = 11;
        hashLib[2].content = "I work under him for a project";

        hashLib[3].hash = 12;
        hashLib[3].content = "He gives me 20,000 rupees a month";

        hashLib[4].hash = 14;
        hashLib[4].content = "The details are secret.";

        hashLib[5].hash = 15;
        hashLib[5].content = "It is under completion";

        hashLib[6].hash = 16;
        hashLib[6].content = "It is private . Not to be shown to anyone";

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public HashText findFromLib(int num)
    {
        foreach(HashText h in hashLib)
        {
            if(num == h.hash)
            {
                return h;
            }
        }
        return null;
    }
    public HashText GetIntroResponse()
    {
        HashText h = new HashText();
        h.hash = 13;
        h.content = "Hie ! What can I do for you?";
        return h;
    }
    public HashText GiveResponse(HashText question)
    {
        HashText h= null;
        if(question.hash == 1)
        {
            return null;
        }
        int t = Analyse(question.hash);
        h = findFromLib(t);
        return h;
    }
    public int Analyse(int hashNo)
    {
        // exit hash 0
        if(hashNo == 0)
        {
            return 0;
        }
        // first 3 question combo
        if(hashNo == 21) // what is your name
        {
            return 10;
        }
        if(hashNo == 22) // why are you here
        {
            return 11;

        }
        if(hashNo == 23) // what is your salary
        {
            return 12;
        }
        // second 3 question combo
        if(hashNo == 24)
        {
            return 14;
        }
        if(hashNo == 25)
        {
            return 15;
        }
        if(hashNo == 26)
        {
            return 16;
        }
        return 0;
    }

}
