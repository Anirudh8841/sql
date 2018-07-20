﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds; 



	void Awake () {
		foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

        }
	}

    public void Play(string str)
    {
        Sound s = Array.Find(sounds, sound => sound.name == str);
        if(s == null)
        {
            return;
        }
        s.source.Play();
    }
    public void Play(int index)
    {
        if(index>= sounds.Length)
        {
            return;
        }
        Sound s = sounds[index];
        s.source.Play();
    }

    public void StopPlaying(int index)
    {
        if (index < 0)
        {
            return;
        }
        Sound s = sounds[index];
        s.source.Stop();
    }
}
