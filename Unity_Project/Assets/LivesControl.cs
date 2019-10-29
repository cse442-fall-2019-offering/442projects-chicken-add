using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LivesControl : MonoBehaviour
{
    public static LivesControl Instance;
    //Global lives and levels variables
    public int life = 3;
    public int level = 1;

    //checks if instance is already running, if not creates a "permanent" game object.
    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
    }
}
