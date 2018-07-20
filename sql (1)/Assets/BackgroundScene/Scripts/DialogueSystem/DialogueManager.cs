using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour {
    #region Singleton
    public static DialogueManager manager;
    void Awake()
    {
        if (manager != null)
        {
            Debug.Log("More than one object of dialoguemanager is created");
            return;
        }
        manager = this;
    }
    #endregion
    
    public Queue<string> sentences;
    [Header("Dialogue Box")]
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI buttonText;
   public AudioManager Audio_manager;
    int index = 0;
    [Header("Canvas Elements")]
    public GameObject TutorialBox;
    [Header("Animator")]
    public Animator anime;

    void Start () { 
        sentences = new Queue<string>();
	}
	
    public void StartDialogue(Dialogue dialogue)
    {
        //Debug.Log("Starting conversation with " + dialogue.name);
        nameText.text = dialogue.name;
        sentences.Clear();
        Audio_manager.Play(0);
        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentences();
    }
    public void DisplayNextSentences()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        if (sentences.Count == 1)
        {
            //update the text on the button
            string nextT = "Next >>";
            buttonText.text = nextT;
            
        }
        Audio_manager.StopPlaying(index-1);
        StopAllCoroutines();

        
           // if index ==0 then there is no previous clip to stop
              // to go to the next clip
        
        
        string sentence = sentences.Dequeue();


        Audio_manager.Play(index);
        dialogueText.text = "";
        index = index + 1;
        StartCoroutine(SmoothLettering(sentence));
        //Debug.Log(sentence);
    }
    IEnumerator SmoothLettering(string sentence)
    {
        foreach(char c in sentence.ToCharArray())
        {
            dialogueText.text += c.ToString();
            yield return null;
        }
    }
    public void EndDialogue()
    {
        
        TutorialBox.SetActive(false);
        anime.SetBool("IsOpen", true);
        //Debug.Log("Next Scene Transition");
    }
}
