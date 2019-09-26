using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("PauseMenu");
    }
}