using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialogue : MonoBehaviour {

    public bool isTalking = false;
    public bool allOptionsPresent = false;
    public HashText[] hashLib;
    public HashText endConvo;

    private void Start()
    {
        endConvo = new HashText();
        endConvo.hash = 1;
        endConvo.content = "Okay!";

        hashLib = new HashText[7];
        for(int i = 0; i < hashLib.Length; i++)
        {
            hashLib[i] = new HashText();
        }
        hashLib[0].hash = 0;
        hashLib[0].content = "See you later";

        hashLib[1].hash = 21;
        hashLib[1].content = "What is your name?";

        hashLib[2].hash = 22;
        hashLib[2].content = "What do you do here?";

        hashLib[3].hash = 23;
        hashLib[3].content = "What's your salary?";


        hashLib[4].hash = 24;
        hashLib[4].content = "Tell me the details of the project?";

        hashLib[5].hash = 25;
        hashLib[5].content = "Then how is it going on?";

        hashLib[6].hash = 26;
        hashLib[6].content = "Can you show me your project?";
    }
    public HashText findFromLib(int num)
    {
        foreach (HashText h in hashLib)
        {
            if (num == h.hash)
            {
                return h;
            }
        }
        return null;
    }

    public HashText[] GetResponse(HashText g)
    {
        int[] h;
        h = Analyse(g.hash);
        
        if (h.Length == 1)
        {
            allOptionsPresent = false;
        }
        else
        {
            allOptionsPresent = true;
        }
        HashText[] responseText = new HashText[h.Length];
        for(int i = 0; i < h.Length; i++)
        {
            responseText[i] = findFromLib(h[i]);
        }
        
        return responseText;
    }
    public int[] Analyse(int hashNo)
    {
        int[] intArr = null;
        if (hashNo == 10|| hashNo == 12 || hashNo == 13|| hashNo == 16)
        {
            allOptionsPresent = true;
            intArr = new int[3];
            intArr[0] = 21;
            intArr[1] = 22;
            intArr[2] = 23;
        }
        if(hashNo == 14|| hashNo == 15|| hashNo == 11)
        {
            allOptionsPresent = true;
            intArr = new int[3];
            intArr[0] = 24;
            intArr[1] = 25;
            intArr[2] = 26;
        }
        if(hashNo == 31)
        {
            allOptionsPresent = false;
            intArr = new int[1];
            intArr[0] = 1;
        }
        return intArr;
    }
    void Update()
    {
        if (isTalking)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                
               HashText hase = DialogueManageSystem.manager.currentOptions[0];
                GuiManager.manager.UpdatePlayerBody(hase.content);
                
                DialogueManageSystem.manager.ConversateNormal(hase);
                
            }
            if (allOptionsPresent)
            {
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    HashText hase = DialogueManageSystem.manager.currentOptions[1];
                    GuiManager.manager.UpdatePlayerBody(hase.content);
                    DialogueManageSystem.manager.ConversateNormal(hase);
                }
                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    HashText hase = DialogueManageSystem.manager.currentOptions[2];
                    GuiManager.manager.UpdatePlayerBody(hase.content);
                    DialogueManageSystem.manager.ConversateNormal(hase);
                }
                if (Input.GetKeyDown(KeyCode.Alpha4))
                {
                    GuiManager.manager.UpdatePlayerBody("Bye Bye");
                    DialogueManageSystem.manager.EndConversation();
                   
                }
            }
        }
    }
}
