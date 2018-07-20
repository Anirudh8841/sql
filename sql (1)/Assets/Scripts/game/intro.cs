using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intro : MonoBehaviour {
    public Animator animator;
    public GameObject player;
    public void introd()
    {
        animator.SetBool("completeIntroduction", true);
        player.SetActive(true);
    }
}
