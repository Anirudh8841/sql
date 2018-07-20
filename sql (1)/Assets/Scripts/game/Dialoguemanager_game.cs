using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialoguemanager_game : MonoBehaviour {
    public  float swait;
    public Text nameText;
    public TextMeshProUGUI dialogueText;
    public Animator animator;
    public audiomanager Audio_manager;
    int index = 0;

    private Queue<string> sentences;

	// Use this for initialization
	void Start () {
        sentences = new Queue<string>();

    }
    public void StartDialogue(Dialogue_game dialogue)
    {
        animator.SetBool("isopen", true);
        nameText.text = dialogue.name;
        sentences.Clear();
        Audio_manager.Play(0);
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
	public void DisplayNextSentence()
    {
        if(sentences.Count==0)
        {
            EndDialogue();
            return;
        }
        string sentence =sentences.Dequeue();
        Audio_manager.StopPlaying(index - 1);

        StopAllCoroutines();
        Audio_manager.Play(index);
        index = index + 1;
        StartCoroutine(TypeSentence(sentence));
        //dialogueText.text = sentence;
    }
    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(swait);
        }
    }
    void EndDialogue()
    {
        animator.SetBool("isopen", false);
    }
	
}
