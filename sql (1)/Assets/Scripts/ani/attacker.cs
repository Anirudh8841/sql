using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[System.Serializable]
public class attacker : MonoBehaviour {

	// Use this for initialization
	
    public float startWait;
   
    public void Attacker_mode()
    {
        StartCoroutine(MyCoroutine());

    }

    IEnumerator MyCoroutine()
    {

        yield return new WaitForSeconds(startWait);
        SceneManager.LoadScene("UiScene",LoadSceneMode.Single);
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
