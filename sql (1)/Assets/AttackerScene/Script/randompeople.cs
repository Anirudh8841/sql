using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randompeople : MonoBehaviour {

    public Transform[] target;
    public Rigidbody rb;
    public float speed;
    private int current=0;
	// Use this for initialization
	void Start () {
       // rbmove();
	}
	
	// Update is called once per frame
	void Update () {
        if (rb.transform.position != target[current].position)
        {
            Vector3 pos = Vector3.MoveTowards(rb.transform.position, target[current].position, speed * Time.deltaTime);
            rb.MovePosition(pos);

        }
        else current = (current + 1) % target.Length;

	}
    
}
