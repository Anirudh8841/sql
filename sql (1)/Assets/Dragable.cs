using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragable : MonoBehaviour {

    // Use this for initialization
    Vector3 point;
    private bool dragging;
    float distance;
	void Start () {
		
	}

    void OnMouseDown()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
    }

    void OnMouseUp()
    {
        dragging = false;
    }

    void Update()
    {
        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = rayPoint;
        }
    }
}
