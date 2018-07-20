using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour {
   
    public float speed;
    private Rigidbody ball;
  //  private int count;
   // public Text counttext;
    //public Text wintext;
    //public Text time;
    // Use this for initialization
    void Start()
    {
        ball = GetComponent<Rigidbody>();
      
    }
   



    // Update is called once per frame
    void FixedUpdate()
    {
        float xmove = Input.GetAxisRaw("Horizontal");
        float ymove = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(xmove, 0.0f, ymove);
        ball.AddForce(movement * speed);
    }

    

}
