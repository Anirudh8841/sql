using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[System.Serializable]
public class victim : MonoBehaviour {

    public float startWait;

     public void Victim_mode()
    {
        StartCoroutine(MyCoroutine());
     

    }
   

    IEnumerator MyCoroutine()
    {

        yield return new WaitForSeconds(startWait);
        SceneManager.LoadScene("sql_game");
        
    }
   
}
