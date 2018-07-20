using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_controller : MonoBehaviour {
    public float speedh = 2.0f;
    public float speedv = 2.0f;
   private float yaw = 0.0f;
    private float pitch = 0.0f;
    public GameObject attacker;
    private Vector3 offset;
    // Use this for initialization
    void Start()
    {
        offset = transform.position - attacker.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = attacker.transform.position + offset;
    }
    void Update()
    {
        yaw += speedh * Input.GetAxis("Mouse X");
        pitch -= speedv * Input.GetAxis("Mouse Y");
      //  transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }

}

