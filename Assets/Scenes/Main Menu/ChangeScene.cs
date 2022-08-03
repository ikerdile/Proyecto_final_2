using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public int SceneNumber;
    public GameObject optionsBackground;

    public void changeScene()
    {
        SceneManager.LoadScene(SceneNumber);
    }

    public void options()
    {
        optionsBackground.SetActive(true);
    }

    public void Back()
    {
        optionsBackground.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }
}          
