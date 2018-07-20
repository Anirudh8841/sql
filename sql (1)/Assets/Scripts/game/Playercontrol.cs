using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playercontrol : MonoBehaviour {
    
    public float speed;
    //private  Rigidbody ball;
    //private int count;
    public CharacterController controller;
    private Vector3 moveDirection;
    public Animator anime;
    public Transform pivot;
    public float rotspeed;
    public GameObject playermodel;
    // Use this for initialization
    void Start () {
      //  ball = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();

      
	}
    void Update()
    {

        moveDirection = (transform.forward* Input.GetAxis("Vertical"))+(transform.right *Input.GetAxis("Horizontal"));
        moveDirection = moveDirection.normalized * speed;

            controller.Move(moveDirection*Time.deltaTime);
        //move the player in different directions based on camera look direction
        if(Input.GetAxis("Horizontal")!=0 || Input.GetAxis("Vertical") != 0)
        {
            transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
            Quaternion newrotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            playermodel.transform.rotation = Quaternion.Slerp(playermodel.transform.rotation, newrotation, rotspeed * Time.deltaTime);
        }
        anime.SetFloat("speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));

    }
  

    

}
