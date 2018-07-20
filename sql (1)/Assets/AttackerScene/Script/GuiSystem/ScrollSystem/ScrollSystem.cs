using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ScrollViewer))]
public class ScrollSystem : MonoBehaviour
{
    AudioSource buttonClickSource;
    ScrollViewer viewUpdate;
    public int scrollIndex = 1;
    int maxScrollIndex = 3;
    bool firstTime= true;
    private void OnEnable()
    {
        if (firstTime)
        {
            //Debug.Log("first time");
            OnPressNext();
            firstTime = false;
        }
    }
    private void Awake()
    {
        buttonClickSource = ButtonManager.manager.GetComponent<AudioSource>();
        //Debug.Log("awake called");
        viewUpdate = GetComponent<ScrollViewer>();
    }
    public void OnPressNext()
    {
        if(buttonClickSource != null)
        {
            buttonClickSource.Play();
        }
        if (scrollIndex == maxScrollIndex)
        {
            scrollIndex = 1;
        }
        else
        {
            scrollIndex = scrollIndex + 1;
        }
        viewUpdate.ActivateObjects(scrollIndex);
    }
    public void OnPressPrevious()
    {
        buttonClickSource.Play();
        scrollIndex = scrollIndex - 1;
        if (scrollIndex == 0)
        {
            scrollIndex = maxScrollIndex;
        }

        viewUpdate.ActivateObjects(scrollIndex);
    }

}
