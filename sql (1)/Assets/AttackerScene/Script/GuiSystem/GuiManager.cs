using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*!
 this contains all the methods for the gui Showing
     */
public class GuiManager : MonoBehaviour {
    #region Singleton
    public static GuiManager manager;
    private void Awake()
    {
        if (manager != null)
        {
            Debug.Log("More than one object of dialoguemanager is created");
            return;
        }
        manager = this;
    }
    #endregion
    public GameObject playerOptionDialogue;
    public GameObject playerDialogue;
    public GameObject interactableDialogue;
    public GameObject Inventory;
    public GameObject Interact;
    public GameObject TalkPanel;
    public GameObject Cancel;

    private bool isShowingCancel;
    public bool isShowingPlayerBox;
    public bool isShowingOptions;
    public bool isShowingInteractableBox;
    private bool isShowingInteract;
    private bool isShowingInventory;
    private bool isShowingTalkPanel;

    void Start () {
        playerDialogue.SetActive(false);
        interactableDialogue.SetActive(false);
        Inventory.SetActive(false);
        Interact.SetActive(false);
        TalkPanel.SetActive(false);
        Cancel.SetActive(false);
        playerOptionDialogue.SetActive(false);

    }
    #region PlayerOption
    public void showOptionsPanel()
    {
        if (isShowingOptions)
        {
            return;
        }
        isShowingOptions = true;
        playerOptionDialogue.SetActive(true);
    }

    public void hideOptionsPanel()
    {
        isShowingOptions = false;
        playerOptionDialogue.SetActive(false);
    }

    public void UpdatePlayerOptions(HashText[] body)
    {
        string bodyText;
        if(body.Length == 1)
        {
            bodyText = "1." + body[0].content + "\n";
        }
        else
        {
            bodyText = "1. " + body[0].content + "\n2. " + body[1].content + "\n3. "+ body[2].content + "\n4. "+"ThatsIt"+"\n";
        }
        
        BoxContainer bc = playerOptionDialogue.GetComponent<BoxContainer>();
        if (isShowingOptions)
        {
            bc.BodyText.text = bodyText;
        }
        else
        {
            showOptionsPanel();
            bc.BodyText.text = bodyText;
        }
    }
    #endregion

    #region Cancel
    public void showCancelConvoButton()
    {
        if (isShowingCancel)
        {
            return;
        }
        isShowingCancel = true;
        Cancel.SetActive(true);
    }
    public void hideCancelConvoButton()
    {
        isShowingCancel = false;
        Cancel.SetActive(false);
    }
    #endregion

    #region Inventory
    public void showInventory()
    {
        if (isShowingInventory)
        {
            return;
        }
        isShowingInventory = true;
        Inventory.SetActive(true);
    }
    public void hideInventory()
    {
        isShowingInventory = false;
        Inventory.SetActive(false);
    }
    #endregion

    #region TalkPanel
    public void showTalkPanel()
    {
        if (isShowingTalkPanel)
        {
            return;
        }
        isShowingTalkPanel = true;
        TalkPanel.SetActive(true);
    }
    public void hideTalkPanel()
    {
        isShowingTalkPanel = false;
        TalkPanel.SetActive(false);
    }
    #endregion

    #region Interact
    public void showInteractButton()
    {
        if (isShowingInteract)
        {
            return;
        }

        isShowingInteract = true;
        Interact.SetActive(true);

    }
    public void hideInteractButton()
    {
        isShowingInteract = false;
        Interact.SetActive(false);
    }
    #endregion

    #region PlayerDialogue
    public void displayPlayerDialogue()
    {
        if (isShowingPlayerBox)
        {
            return;
        }
        isShowingPlayerBox = true;
        // any animation of the player dialogue could be kept in here
        playerDialogue.SetActive(true);
    }
    public void hidePlayerDialogue()
    {
        isShowingPlayerBox = false;
        playerDialogue.SetActive(false);
    }
    public void UpdatePlayerBody(string body)
    {
        BoxContainer bc = playerDialogue.GetComponent<BoxContainer>();
        if (isShowingPlayerBox)
        {
            StartCoroutine(SmoothType(bc.BodyText, body));
        }
        else
        {
            displayPlayerDialogue();
            StartCoroutine(SmoothType(bc.BodyText, body));
        }
    }
    #endregion

    #region TargetDialogue
    public void displayInteractableDialogue()
    {
        if (isShowingInteractableBox)
        {
            return;
        }
        isShowingInteractableBox = true;
        interactableDialogue.SetActive(true);

    }
    public void hideInteractableDialogue()
    {
        isShowingInteractableBox = false;
        interactableDialogue.SetActive(false);
    }
    public void UpdateInteractableHead(string headName)
    {
        BoxContainer bc = interactableDialogue.GetComponent<BoxContainer>();
        bc.HeadingText.text = headName;
    }
    public void UpdateInteractableBody(string body)
    {
        BoxContainer bc = interactableDialogue.GetComponent<BoxContainer>();
        if (isShowingInteractableBox)
        {
            StartCoroutine(SmoothType(bc.BodyText, body));
        }
        else
        {
            displayInteractableDialogue();
            StartCoroutine(SmoothType(bc.BodyText, body));
        }
    }
    #endregion

    public void hideAll()
    {
        hideCancelConvoButton();
        hideInventory();
        hidePlayerDialogue();
        hideOptionsPanel();
        hideInteractableDialogue();
    }


    IEnumerator SmoothType(TextMeshProUGUI tmp,string s)
    {
        
        tmp.text = "";

        foreach(char c in s.ToCharArray())
        {
            tmp.text += c.ToString();
            yield return null;
        }
    }

}
