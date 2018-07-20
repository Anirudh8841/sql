using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManageSystem : MonoBehaviour {

    #region Singleton

    public static DialogueManageSystem manager;

    private void Awake()
    {
        if(manager!= null)
        {
            Debug.Log("More than one DialogueManageSystem is present");
        }
        manager = this;
    }
    #endregion 

    public Transform player;
    public bool isTalkingNormal;
    public bool isTalking = false;
    DialogueStore dialStore;
    PlayerDialogue playerDialogue;

    public HashText[] currentOptions; 
    private void Start()
    {
        playerDialogue = player.GetComponent<PlayerDialogue>();
    }
    void GetInteractableObjectDetails()
    {
        Interactable intera = player.gameObject.GetComponent<PlayerController>().focus;
        GuiManager.manager.UpdateInteractableHead(intera.nameOfObject);
        dialStore = intera.gameObject.GetComponent<DialogueStore>();
    }
    public void StartConvo()
    {
        isTalking = true;
        GetInteractableObjectDetails();
        playerDialogue.isTalking = true;
        if (isTalkingNormal) // start n
        {
            StartNormalConvo();
        }
        else
        {
            StartSweetConvo();
        }
    }
    public void StartNormalConvo()
    {
        // get response form Interactable
        HashText h = dialStore.GetIntroResponse();
        GuiManager.manager.UpdateInteractableBody(h.content);
        currentOptions = playerDialogue.GetResponse(h);
        GuiManager.manager.UpdatePlayerOptions(currentOptions);

    }
    public void ConversateNormal(HashText h)
    {
        HashText g = dialStore.GiveResponse(h);
        if (g == null)
        {
            EndConversation();
            return;
        }
        GuiManager.manager.UpdateInteractableBody(g.content);
        currentOptions = playerDialogue.GetResponse(g);
        GuiManager.manager.UpdatePlayerOptions(currentOptions);

    }
    public void StartSweetConvo()
    {
        
    }
    public void EndConversation() // from player
    {
        StartCoroutine(CleanUpThings());
    }
    public void EndConversationOnCancel()
    {
        GuiManager.manager.UpdateInteractableBody("Its alright");
        StartCoroutine(CleanUpThings());
    }
    IEnumerator CleanUpThings()
    {
        yield return new WaitForSeconds(1.5f);
        GuiManager.manager.hideAll();
        isTalking = false;
        
        dialStore = null;
        playerDialogue.isTalking = false;
        playerDialogue.allOptionsPresent = false;
        playerDialogue.GetComponent<PlayerController>().RemoveFocus();
    }
}
