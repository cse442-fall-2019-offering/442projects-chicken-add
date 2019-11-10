using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelScript : MonoBehaviour
{
    public Text variableText = null;
    int levels;

    //gets the text component from the UI and the global level variable.
    void Start()
    {
        variableText = GetComponent<Text>();
    }

    //constantly updates the current level displayed.
    private void Update()
    {
        levels = LivesControl.Instance.level;
        variableText.text = levels.ToString();
    }

}
