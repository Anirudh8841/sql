using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]

public class main_menu : MonoBehaviour {
    public float startWait;
    public void Playgame()
    {
        StartCoroutine(MyCoroutine());
       

    }
    IEnumerator MyCoroutine()
    {

        yield return new WaitForSeconds(startWait);
        SceneManager.LoadScene("AttackerScene");
    }
    
    public void Quitgame()
    {
        StartCoroutine(MyCoroutine1());

    }
    IEnumerator MyCoroutine1()
    {

        yield return new WaitForSeconds(startWait);
        Debug.Log("quit");
        Application.Quit();
    }
}
