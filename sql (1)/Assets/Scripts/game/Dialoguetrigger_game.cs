using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialoguetrigger_game : MonoBehaviour {
    public Dialogue_game dialogue;
    Dialoguemanager_game manager;
    public void TriggerDialogue()
    {
        FindObjectOfType<Dialoguemanager_game>().StartDialogue(dialogue);
    }
    public void TriggerDialogueaudio()
    {
        manager.StartDialogue(dialogue);
    }
}
