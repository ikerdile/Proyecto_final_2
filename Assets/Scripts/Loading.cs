using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public Text text;

    private void Start()
    {
        string LevelToLoad = LoadLevel.NextLevel;
        StartCoroutine(StartLoad(LevelToLoad));
        

    }

    IEnumerator StartLoad(string level)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(level);
        operation.allowSceneActivation = false;

        while(!operation.isDone)
        {
            if(operation.progress >= 0.9f)
            {
                text.text = "Press key to continue";
                if(Input.anyKey)
                {
                    operation.allowSceneActivation = true;
                }
            }

            yield return null;
        }

    }


}
