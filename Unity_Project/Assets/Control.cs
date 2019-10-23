using UnityEngine;
using UnityEngine.SceneManagement;
public class Control : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("World");
    }
    public void EndScene()
    {
        SceneManager.LoadScene("EndGame");
    }
}
