using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public GameObject word, word_blank;

    Vector2 wordInitPos;
    Vector3 blankPos;
    

    void Start()
    {
        wordInitPos = word.transform.position;
        blankPos = word_blank.transform.position;
        //word2InitPos = word2.transform.position;
        //word3InitPos = word3.transform.position;
        //word4InitPos = word4.transform.position;
    }

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Mouse0))
        {
                   if (Input.GetMouseButtonDown(0))
                   {
                       pythonInitPos.x = Input.mousePosition.x;
                       pythonInitPos.y = Input.mousePosition.y;
                       transform.position = pythonInitPos;
                   }
               }

           */
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(transform.position == blankPos)
        {
            Debug.Log("Right Position");
            transform.position = Input.mousePosition;
        }
        else
        {
            transform.position = wordInitPos;
        }
        
    }
}
