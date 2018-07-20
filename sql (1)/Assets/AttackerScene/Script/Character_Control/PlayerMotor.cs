using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour {
    public Transform target;
    public bool IsFocused = false;
    public NavMeshAgent agent;
	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();	
	}

    private void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
            FaceTarget();
        }
    }
    public void moveToPoint(Vector3 point)
    {

        agent.SetDestination(point);
    }

    public void StopFollowing()
    {
        agent.stoppingDistance = 0f;
        target = null;
        agent.updateRotation = true;
    }

    public void FollowTarget(Interactable focus)
    {
        agent.stoppingDistance=focus.radius * 0.8f;
        agent.updateRotation = false;
        target = focus.transform;
    }
    public void FaceTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookTowards = Quaternion.LookRotation(new Vector3(dir.x, 0f, dir.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookTowards, Time.deltaTime * 5f);
    }
}
