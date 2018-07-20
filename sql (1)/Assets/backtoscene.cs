using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backtoscene : MonoBehaviour {


   public  void Onbuttonclick()
    {
       SceneManager.UnloadScene("Try_scene 1");
    }
}
