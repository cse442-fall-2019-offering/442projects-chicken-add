using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOneManage : MonoBehaviour
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
            SceneManager.LoadScene(sceneIndex - 1);
           
        }
        else
        {
            Application.Quit();
        }
    }
}
