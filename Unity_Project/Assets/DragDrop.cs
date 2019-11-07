using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    public GameObject python, python_blank;

    Vector2 pythonInitPos;

    void Start()
    {
        pythonInitPos = python.transform.position;
    }

    void Update()
    {
     if (Input.GetKeyDown(KeyCode.Mouse0))
     {
                if (Input.GetMouseButtonDown(0))
                {
                    pythonInitPos.x = Input.mousePosition.x;
                    pythonInitPos.y = Input.mousePosition.y;
                    transform.position = pythonInitPos;
                }
            }

        }
    }

