﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLives : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(GameObject.Find("Lives"));

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}