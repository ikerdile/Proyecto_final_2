using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public static class LoadLevel
{
    public static string NextLevel;

    public static void LevelLoad(string name)
    {
        NextLevel = name;
        SceneManager.LoadScene("MetropolyLS");

    }
        
}
