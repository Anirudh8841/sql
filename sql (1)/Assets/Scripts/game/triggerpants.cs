﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class triggerpants : MonoBehaviour {
    public CharacterController controller;
    public GameObject display;
    void OnTriggerEnter(Collider other)
    {
        display.SetActive(true);
    }


}
