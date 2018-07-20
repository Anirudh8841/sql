using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour {

    #region Singleton
    public static ButtonManager manager;

    private void Awake()
    {
        if(manager!= null)
        {
            Debug.Log("More than one instances of the ButtonManager are found");
        }
        manager = this;
    
    }
    #endregion
    AudioSource source;
    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    void PlaySound()
    {
        source.Play();
    }
    public void OnInteractClicked()
    {
        PlaySound();
        GuiManager.manager.showTalkPanel();
        GuiManager.manager.showCancelConvoButton();
        GuiManager.manager.hideInteractButton();
    }
    public void CancelTalkClicked()
    {
        PlaySound();
        GuiManager.manager.hideCancelConvoButton();
        GuiManager.manager.hidePlayerDialogue();
        if (GuiManager.manager.isShowingInteractableBox)
        {
            DialogueManageSystem.manager.EndConversationOnCancel();
            GuiManager.manager.hideInventory();
            return;
        }
        else
        {
            GuiManager.manager.hideInteractableDialogue();
            GuiManager.manager.hideTalkPanel();
        }

    }
    public void OnSweetTalkClicked()
    {
        PlaySound();

        GuiManager.manager.displayInteractableDialogue();
        GuiManager.manager.showInventory();
        GuiManager.manager.hideTalkPanel();
        // start the sweet convo
        DialogueManageSystem.manager.isTalkingNormal = false;
        DialogueManageSystem.manager.StartConvo();
    }
    public void OnNormalTalkClicked()
    {
        PlaySound();

        GuiManager.manager.displayInteractableDialogue();
        GuiManager.manager.hideTalkPanel();
        // start the normal convo
        DialogueManageSystem.manager.isTalkingNormal = true;
        DialogueManageSystem.manager.StartConvo();

    }

}
