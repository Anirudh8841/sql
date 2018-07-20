
/*

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraconroller : MonoBehaviour
{

    private Vector3 offset;
    public Transform target;
    public Transform pivot;
    public float rotatespeed;
    public float maxangle;
    public float minangle;
    // Use this for initialization
    void Start()
    {
        offset = target.position - transform.position;
        pivot.transform.position = target.transform.position;
        // pivot.transform.parent = target.transform;
        pivot.transform.parent = null;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        pivot.transform.position = target.transform.position;
        //get the x of mouse and rotate
        float horizontal = Input.GetAxis("Mouse X") * rotatespeed;
        pivot.Rotate(0, horizontal, 0);
        float vertical = Input.GetAxis("Mouse Y") * rotatespeed;
        pivot.Rotate(vertical, 0, 0);

        if (pivot.rotation.eulerAngles.x > 45f && pivot.rotation.eulerAngles.x < 180f)
        {
            pivot.rotation = Quaternion.Euler(45f, 0f, 0f);
        }
        if (pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < 315f)
        {
            pivot.rotation = Quaternion.Euler(315f, 0f, 0f);
        }
        //move the camera based on rotation of target and original offset 
        float desiredYangle = pivot.eulerAngles.y;
        float desiredXangle = pivot.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(desiredXangle, desiredYangle, 0);
        transform.position = target.position - (rotation * offset);
        // transform.position = target.position - offset;
        if (transform.position.y < target.position.y)
        {
            transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
        }

        transform.LookAt(target);
    }

}
*/



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraconroller : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public Vector3 offset1;
    public float zoomSpeed = 4f;
    public float minZoom = 5f;
    public float maxZoom = 10f;
    public float currentZoom = 10f;
    public float pitch = 2f;
    public float yawSpeed = 4f;
    public float currentYaw = 0;
    public float currentYaw1 = 0;
    public float maxangle;
    public float minangle;

  
    void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        currentYaw -= (-Input.GetAxis("Mouse X" ))* yawSpeed;
        currentYaw1-= (-Input.GetAxis("Mouse Y")) * yawSpeed;
      //  Cursor.lockState = CursorLockMode.Locked;

    }
    void LateUpdate()
    {
        offset1 = new Vector3((target.position.z - transform.position.z), 0, (transform.position.x - target.position.x));
        transform.position = target.position - offset * currentZoom;

        transform.LookAt(target.position + Vector3.up * pitch);
         if (transform.rotation.eulerAngles.x +currentYaw1> maxangle && transform.rotation.eulerAngles.x+currentYaw1 < 180f)
        {
            currentYaw1 = maxangle - transform.rotation.eulerAngles.x;
        }
        if (transform.rotation.eulerAngles.x + currentYaw1 < minangle)
        {
            currentYaw1 =minangle - transform.rotation.eulerAngles.x;
        }

        transform.RotateAround(target.position, Vector3.up, currentYaw);
        transform.RotateAround(target.position,offset1 , currentYaw1);

       

        if (transform.position.y < target.position.y)
        {
            transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
        }

    }
}
