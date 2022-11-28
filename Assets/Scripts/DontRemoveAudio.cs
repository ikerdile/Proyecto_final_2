using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontRemoveAudio : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);

    }

}
