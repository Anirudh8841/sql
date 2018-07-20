using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Preventor : MonoBehaviour {
    public float startWait;

    public void Preventor_mode()
    {
        StartCoroutine(MyCoroutine());


    }


    IEnumerator MyCoroutine()
    {

        yield return new WaitForSeconds(startWait);
        SceneManager.LoadScene("Preventor_scene");

    }
  
}
