using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(DialogueTrigger))]
public class SceneTrigger : MonoBehaviour {
    private bool isTrigger = false;
    public Animator anim;
    DialogueTrigger diaTrig;
    private float count = 0f;
    public float triggerTime = 5f;
	// Use this for initialization
	void Start () {
        diaTrig = GetComponent<DialogueTrigger>();
	}
	
	// Update is called once per frame
	void Update () {
        if (isTrigger)
        {
            return;
        }
        count += Time.deltaTime;
        if (count > triggerTime)
        {
            isTrigger = true;
            count = 0f;
            anim.SetBool("IsOpen", true);
            diaTrig.TriggerDialogue();
            
        }
        
    }
}
