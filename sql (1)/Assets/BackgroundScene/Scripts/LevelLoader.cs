using System.Collections;

using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
public class LevelLoader: MonoBehaviour {

    public TextMeshProUGUI loadpercent;

    public void LoadAttackerScene()
    {
        StartCoroutine(LoadLevel("AttackerScene/AttackerScene"));
    }
    public void LoadVictimScene()
    {
        StartCoroutine(LoadLevel("Scenes/sql_game"));
        Debug.Log("Load the victim scene");
    }
    public void LoadPreventerScene()
    {
        Debug.Log("Load the Preventer scene");
    }
    IEnumerator LoadLevel(string level)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(level);
        while (!operation.isDone)
        {
            float f = operation.progress;
            int percent =(int)((f / 0.9f)* 100);
            loadpercent.text = "Loading... "+ percent.ToString() + "%";
            yield return new WaitForSeconds(0.2f);
        }
    }
}
