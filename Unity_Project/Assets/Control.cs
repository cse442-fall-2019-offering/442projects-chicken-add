using UnityEngine;
using UnityEngine.SceneManagement;
#comment
public class Control : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("Game");
    }
}
