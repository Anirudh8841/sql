using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public Transform target;
    public Vector3 offset;
    private float zoom = 3f;
    public float rotateSpeed = 4f;
    public float zoomSpeed = 4f;
    public float minZoom = 3f;
    public float maxZoom = 10f;
    public float currentAngle = 0f;
    public float pitch = 3f;
    private void Start()
    {
        //offset = new Vector3(-2f, -1.56f, -5.64f);
        if (target == null)
            Debug.Log("player transform not attached to camera script");
    }
    private void Update()
    {
        zoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        zoom = Mathf.Clamp(zoom, minZoom, maxZoom);

        currentAngle -= Input.GetAxis("Horizontal") * rotateSpeed;

    }
    private void LateUpdate()
    {
        
        transform.position = target.position - offset * zoom;
        transform.LookAt(target.position + Vector3.up * pitch);

        transform.RotateAround(target.position, Vector3.up, currentAngle);
    }
}
