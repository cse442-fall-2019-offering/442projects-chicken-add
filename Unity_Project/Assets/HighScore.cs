using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    // Start is called before the first frame update
    void Start(){
         entryContainer = transform.Find("scoringContainer");
        entryTemplate = transform.Find("scoringTemplate");
        entryTemplate.gameObject.SetActive(false);
        
        float templateHeight = 30f;
        for(int i = 0; i < 10; ++i){
            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
            entryTransform.gameObject.SetActive(true);
        }
    }
    

    // Update is called once per frame
    void Update(){
       
    }  
}