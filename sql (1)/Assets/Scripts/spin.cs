using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spin : MonoBehaviour {

    public Button mybutton1;

    void Start()
    {
        mybutton1.GetComponentInChildren<Text>().text = "Stop";
       
    }

    public void Onclickb()
    {
        if (mybutton1.GetComponentInChildren<Text>().text == "Stop")
        {
            mybutton1.GetComponentInChildren<Text>().text = "Spin";
        }
        else if (mybutton1.GetComponentInChildren<Text>().text == "Spin")
        {
            mybutton1.GetComponentInChildren<Text>().text = "Stop";
        }
    }

    public void Spinchar()
    {
        if (mybutton1.GetComponentInChildren<Text>().text == "Stop")
        {
            transform.Rotate(new Vector3(0, 100, 0) * Time.deltaTime);
        }
        else if (mybutton1.GetComponentInChildren<Text>().text == "Spin")
        {
           
        }
    }
    // Update is called once per frame
    void Update () {
        Spinchar();
	}
}
