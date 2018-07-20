using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changedress : MonoBehaviour {
    public Material dress;
    public Texture[] textures;
    private Texture onbody;
    private int a;
    private int shirt;
    private int pant;

    
    void Start()
    {

        onbody = dress.GetTexture("_MainTex");
       for(int i=0;i<16;i++)
        {
            if(textures[i]==onbody)
            {
                a = i;
                i = 16;
            }

        }
        shirt = a / 4;
        pant = a % 4;


       dress.mainTexture= textures[0];
       // dress.mainTexture = onbody;



    }

}
