using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class volumecontroller : MonoBehaviour {

    public AudioMixer audiomixer;
 public void setvolume(float volume)
     {
        audiomixer.SetFloat("volume", volume);
    }
}
