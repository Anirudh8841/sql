using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class CharacterAnimation : MonoBehaviour {

    Animator animator;
    NavMeshAgent agent;

	// Use this for initialization
	void Start () {
        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
	}
	
	
	void Update () {
        float speedPercent = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("manSpeed", speedPercent);
	}
}
