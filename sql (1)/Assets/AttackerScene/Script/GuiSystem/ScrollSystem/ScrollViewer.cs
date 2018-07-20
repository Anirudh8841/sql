using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewer : MonoBehaviour {

    public GameObject[] scrollObjects;

    void Awake()
    {
        int child_count = transform.childCount;
        scrollObjects = new GameObject[child_count - 3];
        for(int i = 3; i < child_count; i++)
        {
            scrollObjects[i - 3] = transform.GetChild(i).gameObject;
        }
        for (int i = 0; i < scrollObjects.Length; i++) {

            scrollObjects[i].GetComponent<Button>().onClick.AddListener(delegate { OnCardClick(i); });
        }
    }

    void OnCardClick(int i)
    {
        // clicked the ith card listner

        
    }
    public void ActivateObjects(int scrollIndex)
    {
        foreach(GameObject g in scrollObjects)
        {
            g.SetActive(false);
        }
        for(int i = 3*(scrollIndex -1); i< 3*scrollIndex; i++)
        {
            scrollObjects[i].SetActive(true);
        }
    }
}
