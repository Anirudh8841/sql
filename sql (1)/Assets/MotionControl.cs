using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionControl : MonoBehaviour {
    Camera cam;
    public float speed = 5f;
    CameraControl camControl;
	// Use this for initialization
	void Start () {
        
        cam = Camera.main;
        camControl = cam.GetComponent<CameraControl>();
	}
	
	// Update is called once per frame
	void Update () {

        float v = Input.GetAxis("Vertical");
        Vector3 v2 = new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z);
        transform.Translate(v * Time.deltaTime * v2* speed);
        LookForward();
        

        
	}
    void LookForward()
    {
        Vector3 dir = cam.transform.forward;
        Quaternion lookTowards = Quaternion.LookRotation(new Vector3(dir.x,0,dir.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookTowards, Time.deltaTime * 5f);

    }

}
