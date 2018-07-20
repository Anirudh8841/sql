using System.Collections;
using UnityEngine;

public class day_night : MonoBehaviour {
    public float timePeriod = 5.0f;
    private float speed;
    // Use this for initialization

    void Update()
    {
        // 360 -   timeperiod
        speed = 360 / timePeriod;
        Vector3 v = new Vector3(Time.deltaTime*speed,0.0f,0.0f);   

        transform.Rotate(v,Space.World);
    }

}
