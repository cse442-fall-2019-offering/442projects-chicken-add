using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop2 : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField]
    public GameObject word, blank_word;

    private Vector2 blankPos;

    private Vector2 wordInitPos;

    //private Vector2 blankPos;

    public static bool win2;



    void Start()
    {
        wordInitPos = word.transform.position;
        blankPos = blank_word.transform.position;

       // win = false;
    }

    void Update()
    {

    }
    public void OnDrag(PointerEventData eventData)
    {
        //if (!locked)
        // {

        transform.position = Input.mousePosition;

        // }
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        if (Mathf.Abs(transform.position.x - blankPos.x) <= 50.0f &&
           Mathf.Abs(transform.position.y - blankPos.y) <= 50.0f)
        {
            Debug.Log("Right Position");
            transform.position = new Vector2(blankPos.x, blankPos.y);
            win2 = true;

        }
        else
        {
            transform.position = wordInitPos;
            win2 = false;
        }

    }
}
