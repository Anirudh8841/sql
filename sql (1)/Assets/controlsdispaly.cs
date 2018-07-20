using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controlsdispaly : MonoBehaviour {
    public Button controls;
    public GameObject display;
    public void displaycontrols()
        {
        if(display.activeInHierarchy)
        {
            display.SetActive(false);
        }
        else
            display.SetActive(true);

    }
	
}
