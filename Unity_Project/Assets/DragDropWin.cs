using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DragDropWin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        /*Debug.Log("1: " + DragDrop.win1);
        Debug.Log("2: " + DragDrop2.win2);
        Debug.Log("3: " + DragDrop3.win3);
        Debug.Log("4: " + DragDrop4.win4);*/
        CheckWin();

    }
    void CheckWin()
    {
        if((DragDrop.win1 && DragDrop2.win2 && DragDrop3.win3 && DragDrop4.win4) == true)
        {
            Debug.Log("You Win");
            SceneManager.LoadScene("EndGame");
        }
    }
}
