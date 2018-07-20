using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]

public class loadimg : MonoBehaviour
{

    public Image myimage;

    public Sprite blockA;
    public Sprite blockB;
    
    private int counter = 0;

    // Use this for initialization
    void Start()
    {
        myimage = GetComponent<Image>();


    }

    public void changeButton()
    {
        counter++;
        if (counter % 2 == 0)
        {
            myimage.overrideSprite = blockA;

        }
        else 
        {
            myimage.overrideSprite = blockB;
        }
      
    }

}
