using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerMM : MonoBehaviour
{
    int sceneIndex; 
    //used to track which scene we are on
    public void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    public void Back()
    {
        if (sceneIndex > 0)
        {
            SceneManager.LoadScene(0);
            sceneIndex = 0;
            Debug.Log("BACK");
           
        }
        else
        {
            Application.Quit();
        }
    }
}
